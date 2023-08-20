namespace KinoPlus.Models
{
    public class UserSearchObject : BaseSearchObject
    {
        public string NameFTS { get; set; }
        public int? RoleId { get; set; }
    }
}
