using KinoPlus.Models;

namespace KinoPlus.WinUI
{
    public static class Cache
    {
        public static List<MovieDto> Movies { get; set; } = new List<MovieDto>();
        public static List<MovieStatusDto> MovieStatuses { get; set; } = new List<MovieStatusDto>();
        public static List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public static List<ProjectionTypeDto> ProjectionTypes { get; set; } = new List<ProjectionTypeDto>();
        public static List<YearDto> Years { get; set; } = new List<YearDto>();
        public static List<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public static List<ActorDto> Actors { get; set; } = new List<ActorDto>();
        public static List<LocationDto> Locations { get; set; } = new List<LocationDto>();
        public static List<CityDto> Cities { get; set; } = new List<CityDto>();
        public static List<HallDto> Halls { get; set; } = new List<HallDto>();
        public static List<WeekDayDto> WeekDays { get; set; } = new List<WeekDayDto>();


        public static List<T> GetList<T>()
        {
            if (typeof(List<T>) == Movies.GetType())
            {
                return (List<T>)(object)Movies;
            }
            if (typeof(List<T>) == MovieStatuses.GetType())
            {
                return (List<T>)(object)MovieStatuses;
            }
            if (typeof(List<T>) == Categories.GetType())
            {
                return (List<T>)(object)Categories;
            }
            if (typeof(List<T>) == ProjectionTypes.GetType())
            {
                return (List<T>)(object)ProjectionTypes;
            }
            if (typeof(List<T>) == Years.GetType())
            {
                return (List<T>)(object)Years;
            }
            if (typeof(List<T>) == Genres.GetType())
            {
                return (List<T>)(object)Genres;
            }
            if (typeof(List<T>) == Actors.GetType())
            {
                return (List<T>)(object)Actors;
            }
            if (typeof(List<T>) == Locations.GetType())
            {
                return (List<T>)(object)Locations;
            }
            if (typeof(List<T>) == Cities.GetType())
            {
                return (List<T>)(object)Cities;
            }
            if (typeof(List<T>) == Halls.GetType())
            {
                return (List<T>)(object)Halls;
            }
            if (typeof(List<T>) == WeekDays.GetType())
            {
                return (List<T>)(object)WeekDays;
            }

            throw new Exception("non existant cache entity");
        }

        public static void Remove<T>()
        {
            if (typeof(List<T>) == Movies.GetType())
            {
                Movies.Clear();
                return;
            }
            if (typeof(List<T>) == Locations.GetType())
            {
                Locations.Clear();
                return;
            }
            if (typeof(List<T>) == Categories.GetType())
            {
                Categories.Clear();
                return;
            }

            throw new Exception("non existant cache entity");
        }
    }
}
