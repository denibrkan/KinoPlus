using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();

        }
    }
}
