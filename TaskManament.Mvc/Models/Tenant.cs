using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManament.Mvc.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string TenantDescription { get; set; } = string.Empty;
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }

        public static void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.TenantDescription).IsRequired();
            builder.Property(e => e.Date_Created).IsRequired();
            builder.Property(e => e.Date_Modified).IsRequired();
        }
    }
}
