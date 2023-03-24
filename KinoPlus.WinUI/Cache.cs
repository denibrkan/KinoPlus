using KinoPlus.Models;

namespace KinoPlus.WinUI
{
    public static class Cache
    {
        public static List<MovieStatusDto> MovieStatuses { get; set; } = new List<MovieStatusDto>();
        public static List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public static List<YearDto> Years { get; set; } = new List<YearDto>();
        public static List<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public static List<ActorDto> Actors { get; set; } = new List<ActorDto>();
    }
}
