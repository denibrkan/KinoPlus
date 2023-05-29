using AutoMapper;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;

namespace KinoPlus.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly KinoplusContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public RecommendationService(KinoplusContext context, IMapper mapper, IMovieService movieService)
        {
            _context = context;
            _mapper = mapper;
            _movieService = movieService;
        }

        public async Task<List<Movie>> Recommend(int userId)
        {
            var user = _context.Users
                .Include(u => u.MovieReactions)
                .SingleOrDefault(u => u.Id == userId);

            if (user == null) throw new Exception("User does not exist!");

            if (!user.MovieReactions.Any())
            {
                return await _movieService.GetMostPopularAsync();
            }

            // set up a new machine learning context
            var mlContext = new MLContext();

            var model = LoadModel(mlContext);

            var activeStatus = _context.MovieStatuses.Single(s => s.Name == "Active");

            var movieIds = _context.Movies
                            .Where(m => m.MovieStatusId == activeStatus.Id)
                            .Select(x => x.Id)
                            .ToList();

            var recommendedMovieIds = GetMoviePredictions(mlContext, model, userId, movieIds);

            return _movieService.GetByIds(recommendedMovieIds);
        }

        ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingData)
        {
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "UserIdEncoded",
                MatrixRowIndexColumnName = "MovieIdEncoded",
                LabelColumnName = "Rating",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            // step 1: map userId and movieId to keys
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "UserId",
                    outputColumnName: "UserIdEncoded")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "MovieId",
                    outputColumnName: "MovieIdEncoded")

                // step 2: find recommendations using matrix factorization
                .Append(mlContext.Recommendation().Trainers.MatrixFactorization(options)));

            // train the model
            Console.WriteLine("Training the model...");
            var model = pipeline.Fit(trainingData);

            return model;
        }

        void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
        {
            var prediction = model.Transform(testDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Rating", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());
        }

        List<int> GetMoviePredictions(MLContext mlContext, ITransformer model, int userId, List<int> movieIds)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(model);
            var predictionList = new List<MovieRatingPrediction>();

            foreach (var movieId in movieIds)
            {
                var testInput = new MovieRating { UserId = userId, MovieId = movieId };

                var prediction = predictionEngine.Predict(testInput);
                prediction.MovieId = movieId;

                Console.WriteLine($"User id {userId} movie prediction : Movie id {movieId}\nScore: {prediction.Score}");

                predictionList.Add(prediction);
            }

            return predictionList
                .OrderByDescending(p => p.Score)
                .Take(5)
                .Select(p => p.MovieId)
                .ToList();
        }

        List<MovieRating> GetTestData()
        {
            var testDataList = new List<MovieRating>
            {
                new MovieRating
                {
                    UserId = 19,
                    MovieId = 9,
                    Rating = 5,
                },

                new MovieRating
                {
                    UserId = 20,
                    MovieId = 9,
                    Rating = 5,
                },

                new MovieRating
                {
                    UserId = 19,
                    MovieId = 10,
                    Rating = 5,
                },

                new MovieRating
                {
                    UserId = 20,
                    MovieId = 10,
                    Rating = 5,
                }
            };

            return testDataList;
        }

        ITransformer LoadModel(MLContext mlContext)
        {
            DataViewSchema modelSchema;

            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");
            // Load trained model
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);

            return trainedModel;
        }

        public async Task CreateModel()
        {
            var mlContext = new MLContext();

            var ratings = await _context.MovieReactions.ToListAsync();
            var trainingData = mlContext.Data.LoadFromEnumerable(_mapper.Map<IEnumerable<MovieRating>>(ratings));
            var testData = mlContext.Data.LoadFromEnumerable(GetTestData());

            ITransformer model = BuildAndTrainModel(mlContext, trainingData);

            EvaluateModel(mlContext, testData, model);

            SaveModel(mlContext, trainingData.Schema, model);
        }

        void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");

            Console.WriteLine("=============== Saving the model to a file ===============");
            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }
    }

    public class MovieRating
    {
        public int UserId;
        public int MovieId;
        public float Rating;
    }

    public class MovieRatingPrediction
    {
        public float Score;
        public int MovieId;
    }
}
