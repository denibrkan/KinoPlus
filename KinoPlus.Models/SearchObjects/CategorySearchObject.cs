namespace KinoPlus.Models
{
    public class CategorySearchObject : BaseSearchObject
    {
        public bool? IncludeMoviesWithData { get; set; }
        public bool? IncludeMovies { get; set; }
        public bool? IsDisplayed { get; set; }
        public string NameFTS { get; set; }
    }
}
