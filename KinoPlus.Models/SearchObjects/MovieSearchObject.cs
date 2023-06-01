namespace KinoPlus.Models
{
    public class MovieSearchObject : BaseSearchObject
    {
        public string TitleFTS { get; set; }
        public int? StatusId { get; set; }
        public int? CategoryId { get; set; }
        public int? GenreId { get; set; }
        public bool? ActiveOnly { get; set; }
        public string SortBy { get; set; }
    }
}
