namespace TaskManament.Mvc.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string TenantDescription { get; set; } = string.Empty;
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
    }
}
