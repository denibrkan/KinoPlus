using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IRecommendationService
    {
        Task<List<Movie>> Recommend(int userId);
        Task CreateModel();
    }
}
