namespace KinoPlus.Models
{
    public class TicketSearchObject : BaseSearchObject
    {
        public int[] Ids { get; set; }
        public int? UserId { get; set; }
    }
}
