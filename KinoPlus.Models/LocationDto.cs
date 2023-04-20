using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CityDto City { get; set; }
        public List<HallDto> Halls { get; set; }
        public List<ProjectionTypeDto> ProjectionTypes { get; set; }
    }
}