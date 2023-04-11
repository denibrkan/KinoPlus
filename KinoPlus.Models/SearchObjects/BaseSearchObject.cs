namespace KinoPlus.Models
{
    public class BaseSearchObject
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string Include { get; set; }
    }
}
