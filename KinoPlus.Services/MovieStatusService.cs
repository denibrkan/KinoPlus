using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class MovieStatusService : BaseService<MovieStatus, BaseSearchObject>, IMovieStatusService
    {
        public MovieStatusService(KinoplusContext context) : base(context)
        {

        }
    }
}
