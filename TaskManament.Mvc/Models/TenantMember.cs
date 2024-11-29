using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManament.Mvc.Models
{
    public class TenantMember
    {
        public int TenantId { get; set; }
        public int UserId { get; set; }

        public Tenant Tenant { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public static void Configure(EntityTypeBuilder<TenantMember> builder)
        {
            builder.HasKey(e => new { e.TenantId, e.UserId });
            builder.HasOne(e => e.Tenant).WithMany().HasForeignKey(e => e.TenantId);
            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
