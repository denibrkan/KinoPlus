namespace KinoPlus.Models
{
    public class BaseSearchObject
    {
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string Include { get; set; }
    }
}
