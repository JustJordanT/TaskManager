using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManament.Mvc.Models
{
    public class ApplicationUser
    {
        // Could be some edge cases where EntraID is updated but this is not updated.
        public int Id { get; set; }
        public string EntraID { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public bool FirstTimeLogin { get; set; } = true;

        public static void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EntraID).IsRequired();
            builder.Property(e => e.DisplayName).IsRequired();
            builder.Property(e => e.Email).IsRequired();
        }
    }
}

