using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

namespace KinoPlus.Services.Data
{
    public class Seed
    {
        public static async Task SeedEntities(KinoplusContext db)
        {
            string applicationDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).AbsolutePath) + '/';
            if (!await db.Roles.AnyAsync())
            {
                var roleData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Roles.json");
                var roles = JsonSerializer.Deserialize<List<Role>>(roleData);
                if (roles == null) return;

                await db.AddRangeAsync(roles);
                await db.SaveChangesAsync();
            }
            if (!await db.Users.AnyAsync())
            {
                var usersData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Users.json");
                var users = JsonSerializer.Deserialize<List<User>>(usersData);
                if (users == null) return;

                await db.AddRangeAsync(users);
                await db.SaveChangesAsync();
            }
            if (!await db.UserRoles.AnyAsync())
            {
                var userRoleData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/UserRoles.json");
                var userRoles = JsonSerializer.Deserialize<List<UserRole>>(userRoleData);
                if (userRoles == null) return;

                await db.AddRangeAsync(userRoles);
                await db.SaveChangesAsync();
            }
            if (!await db.ProjectionTypes.AnyAsync())
            {
                var projectionTypeData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/ProjectionTypes.json");
                var projectionTypes = JsonSerializer.Deserialize<List<ProjectionType>>(projectionTypeData);
                if (projectionTypes == null) return;

                await db.AddRangeAsync(projectionTypes);
                await db.SaveChangesAsync();
            }
            if (!await db.Categories.AnyAsync())
            {
                var categorieData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categorieData);
                if (categories == null) return;

                await db.AddRangeAsync(categories);
                await db.SaveChangesAsync();
            }
            if (!await db.Actors.AnyAsync())
            {
                var actorData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Actors.json");
                var actors = JsonSerializer.Deserialize<List<Actor>>(actorData);
                if (actors == null) return;

                await db.AddRangeAsync(actors);
                await db.SaveChangesAsync();
            }
            if (!await db.Genres.AnyAsync())
            {
                var genreData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genreData);
                if (genres == null) return;

                await db.AddRangeAsync(genres);
                await db.SaveChangesAsync();
            }
            if (!await db.Years.AnyAsync())
            {
                var yearData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Years.json");
                var years = JsonSerializer.Deserialize<List<Year>>(yearData);
                if (years == null) return;

                await db.AddRangeAsync(years);
                await db.SaveChangesAsync();
            }
            if (!await db.MovieStatuses.AnyAsync())
            {
                var statusData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Statuses.json");
                var statuses = JsonSerializer.Deserialize<List<MovieStatus>>(statusData);
                if (statuses == null) return;

                await db.AddRangeAsync(statuses);
                await db.SaveChangesAsync();
            }
            if (!await db.Halls.AnyAsync())
            {
                var hallData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Halls.json");
                var halls = JsonSerializer.Deserialize<List<Hall>>(hallData);
                if (halls == null) return;

                await db.AddRangeAsync(halls);
                await db.SaveChangesAsync();
            }
            if (!await db.Seats.AnyAsync())
            {
                var seatData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Seats.json");
                var seats = JsonSerializer.Deserialize<List<Seat>>(seatData);
                if (seats == null) return;

                await db.AddRangeAsync(seats);
                await db.SaveChangesAsync();
            }
            if (!await db.Countries.AnyAsync())
            {
                var countryData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Countries.json");
                var countries = JsonSerializer.Deserialize<List<Country>>(countryData);
                if (countries == null) return;

                await db.AddRangeAsync(countries);
                await db.SaveChangesAsync();
            }
            if (!await db.Cities.AnyAsync())
            {
                var cityData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Cities.json");
                var cities = JsonSerializer.Deserialize<List<City>>(cityData);
                if (cities == null) return;

                await db.AddRangeAsync(cities);
                await db.SaveChangesAsync();
            }
            if (!await db.Locations.AnyAsync())
            {
                var locationData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Locations.json");
                var locations = JsonSerializer.Deserialize<List<Location>>(locationData);
                if (locations == null) return;

                await db.AddRangeAsync(locations);
                await db.SaveChangesAsync();
            }
            if (!await db.LocationHalls.AnyAsync())
            {
                var locationHallData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/LocationHalls.json");
                var locationHalls = JsonSerializer.Deserialize<List<LocationHall>>(locationHallData);
                if (locationHalls == null) return;

                await db.AddRangeAsync(locationHalls);
                await db.SaveChangesAsync();
            }
            if (!await db.LocationProjectionTypes.AnyAsync())
            {
                var locationProjectionTypeData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/LocationProjectionTypes.json");
                var locationProjectionTypes = JsonSerializer.Deserialize<List<LocationProjectionType>>(locationProjectionTypeData);
                if (locationProjectionTypes == null) return;

                await db.AddRangeAsync(locationProjectionTypes);
                await db.SaveChangesAsync();
            }
            if (!await db.WeekDays.AnyAsync())
            {
                var dayData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/WeekDays.json");
                var days = JsonSerializer.Deserialize<List<WeekDay>>(dayData);
                if (days == null) return;

                await db.AddRangeAsync(days);
                await db.SaveChangesAsync();
            }
            if (!await db.Movies.AnyAsync())
            {
                var movieData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/Movies.json");
                var movies = JsonSerializer.Deserialize<List<Movie>>(movieData);
                if (movies == null) return;

                await db.AddRangeAsync(movies);
                await db.SaveChangesAsync();
            }
            if (!await db.MovieGenres.AnyAsync())
            {
                var movieGenreData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/MovieGenres.json");
                var movieGenres = JsonSerializer.Deserialize<List<MovieGenre>>(movieGenreData);
                if (movieGenres == null) return;

                await db.AddRangeAsync(movieGenres);
                await db.SaveChangesAsync();
            }
            if (!await db.MovieCategories.AnyAsync())
            {
                var movieCategoryData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/MovieCategories.json");
                var movieCategories = JsonSerializer.Deserialize<List<MovieCategory>>(movieCategoryData);
                if (movieCategories == null) return;

                await db.AddRangeAsync(movieCategories);
                await db.SaveChangesAsync();
            }
            if (!await db.MovieActors.AnyAsync())
            {
                var movieActorData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/MovieActors.json");
                var movieActors = JsonSerializer.Deserialize<List<MovieActor>>(movieActorData);
                if (movieActors == null) return;

                await db.AddRangeAsync(movieActors);
                await db.SaveChangesAsync();
            }
            if (!await db.MovieReactions.AnyAsync())
            {
                var reactionData = await System.IO.File.ReadAllTextAsync(applicationDir + "Data/Seed/MovieReactions.json");
                var reactions = JsonSerializer.Deserialize<List<MovieReaction>>(reactionData);
                if (reactions == null) return;

                await db.AddRangeAsync(reactions);
                await db.SaveChangesAsync();
            }
        }

        public static async Task SeedImages(KinoplusContext db, IImageService imageService)
        {
            if (db.Images.Any()) return;

            string applicationDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).AbsolutePath) + '/';
            string imgDirPath = applicationDir + "Data/Images";

            //sorted alphabetically
            var imagePaths = Directory.GetFiles(imgDirPath, "*.jp*g").OrderBy(f => f);
            var images = new List<ImageInputModel>();

            foreach (var imgPath in imagePaths)
            {
                var fileStream = File.OpenRead(imgPath);
                var image = new ImageInputModel
                {
                    FileName = Path.GetFileName(imgPath),
                    Content = fileStream,
                };

                images.Add(image);
            }

            var imageIds = await imageService.ProcessAsync(images);

            var movies = db.Movies.OrderBy(x => x.Title).ToList();

            for (int i = 0; i < movies.Count; i++)
            {
                movies[i].ImageId = imageIds[i];
            }

            await db.SaveChangesAsync();
        }
    }
}
