namespace KinoPlus.Models
{
    public class LocationHallDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int HallId { get; set; }
        public LocationDto Location { get; set; }
        public HallDto Hall { get; set; }
    }
}
