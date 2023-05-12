using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services;
using KinoPlus.Services.Database;

namespace KinoPlus.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(x => x.Categories, options => options.MapFrom(y => y.MovieCategories.Select(z => z.Category)))
                .ForMember(x => x.Genres, options => options.MapFrom(y => y.MovieGenres.Select(z => z.Genre)))
                .ForMember(x => x.Actors, options => options.MapFrom(y => y.MovieActors.Select(z => z.Actor)))
                .ForMember(x => x.Reactions, options => options.MapFrom(y => y.MovieReactions))
                .ForMember(x => x.Status, options => options.MapFrom(y => y.MovieStatus))
                .ForMember(x => x.AverageRating, options => options.MapFrom(y => CalculateAverageRating(y.MovieReactions)));

            CreateMap<MovieUpsertObject, Movie>()
                .ForMember(x => x.MovieStatusId, opt => opt.MapFrom(y => y.StatusId));

            CreateMap<MovieReaction, MovieReactionDto>();
            CreateMap<MovieReactionUpsertObject, MovieReaction>();
            CreateMap<MovieStatus, MovieStatusDto>();

            CreateMap<Movie, CategoryMovieDto>()
                .ForMember(x => x.Genres, options => options.MapFrom(y => y.MovieGenres.Select(z => z.Genre)))
                .ForMember(x => x.Actors, options => options.MapFrom(y => y.MovieActors.Select(z => z.Actor)))
                .ForMember(x => x.Reactions, options => options.MapFrom(y => y.MovieReactions))
                .ForMember(x => x.Status, options => options.MapFrom(y => y.MovieStatus))
                .ForMember(x => x.AverageRating, options => options.MapFrom(y => CalculateAverageRating(y.MovieReactions)));

            CreateMap<Category, MovieCategoryDto>();
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.Movies, options => options.MapFrom(y => y.MovieCategories.Select(z => z.Movie)));
            CreateMap<CategoryInsertObject, Category>();
            CreateMap<CategoryUpdateObject, Category>();

            CreateMap<User, UserDto>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(y => y.UserRoles.Select(z => z.Role)))
                .ForMember(x => x.MovieCount, opt => opt.MapFrom(y => y.Tickets.Select(t => t.Projection.MovieId).Distinct().Count()))
                .ForMember(x => x.LoyaltyPoints, opt => opt.MapFrom(y => y.Tickets.Select(t => t.Projection.Price).Sum()))
                .ForMember(x => x.MoviesWatched, opt => opt.MapFrom(y => y.Tickets.Select(z => z.Projection.Movie).Distinct()));

            CreateMap<UserInsertObject, User>();
            CreateMap<UserUpdateObject, User>();

            CreateMap<Role, RoleDto>();

            CreateMap<ActorUpsertObject, Actor>();
            CreateMap<Actor, ActorDto>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreUpsertObject, Genre>();

            CreateMap<Projection, ProjectionDto>()
                .ForMember(x => x.TicketCount, opt => opt.MapFrom(y => y.Tickets.Count));

            CreateMap<ProjectionInsertObject, Projection>();
            CreateMap<ProjectionType, ProjectionTypeDto>();
            CreateMap<ProjectionLocation, LocationHallDto>();

            CreateMap<LocationUpsertObject, Location>();
            CreateMap<Location, LocationDto>()
                .ForMember(x => x.Halls, opt => opt.MapFrom(y => y.LocationHalls.Select(z => z.Hall)))
                .ForMember(x => x.ProjectionTypes, opt => opt.MapFrom(y => y.LocationProjectionTypes.Select(z => z.ProjectionType)));

            CreateMap<Hall, HallDto>();
            CreateMap<Seat, SeatDto>();
            CreateMap<Ticket, TicketDto>()
                .ForMember(x => x.Hall, opt => opt.MapFrom(y => y.Projection.Hall))
                .ForMember(x => x.Location, opt => opt.MapFrom(y => y.Projection.Location))
                .ForMember(x => x.MovieTitle, opt => opt.MapFrom(y => y.Projection.Movie.Title))
                .ForMember(x => x.MovieImageId, opt => opt.MapFrom(y => y.Projection.Movie.ImageId))
                .ForMember(x => x.ProjectionStart, opt => opt.MapFrom(y => y.Projection.StartsAt))
                .ForMember(x => x.ProjectionEnd, opt => opt.MapFrom(y => y.Projection.EndsAt));

            CreateMap<City, CityDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Year, YearDto>();
            CreateMap<WeekDay, WeekDayDto>();

            CreateMap<MovieReaction, MovieRating>();
        }

        public double CalculateAverageRating(IEnumerable<MovieReaction> reactions)
        {
            if (reactions.Any())
            {
                return reactions.Average(x => x.Rating);
            }
            return 0;
        }
    }
}
