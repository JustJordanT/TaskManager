namespace TaskManament.Mvc.Models
{
    public class ApplicationUser
    {
        // Could be some edge cases where EntraID is updated but this is not updated.
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string EntraID { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
