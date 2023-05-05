using System;

namespace KinoPlus.Models
{
    public class ProjectionSearchObject : BaseSearchObject
    {
        public DateTime? Date { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? LocationId { get; set; }
        public int? MovieId { get; set; }
    }
}
