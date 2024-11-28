namespace TaskManament.Mvc.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public int ProjectOwner { get; set; }
        public string ProjectDescription { get; set; } = string.Empty;
        public string ProjectStatus { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
