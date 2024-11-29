using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManament.Mvc.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public Team Team { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasKey(e => new { e.TeamId, e.UserId });
            builder.HasOne(e => e.Team).WithMany().HasForeignKey(e => e.TeamId);
            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
