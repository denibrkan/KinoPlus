using System;
using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public Guid ImageId { get; set; }
        public string TrailerUrl { get; set; }
        public double AverageRating { get; set; }
        public DateTime DateCreated { get; set; }
        public YearDto Year { get; set; }
        public MovieStatusDto Status { get; set; }
        public List<MovieCategoryDto> Categories { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<ReactionDto> Reactions { get; set; }
        //public List<ProjectionDto> Projections { get; set; }
    }
}
