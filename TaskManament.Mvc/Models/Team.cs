namespace TaskManament.Mvc.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int TeamOwner { get; set; }
        public string TeamDescription { get; set; } = string.Empty;
        public string TeamStatus { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
