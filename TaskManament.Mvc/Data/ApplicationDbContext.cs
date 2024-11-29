using Microsoft.EntityFrameworkCore;

namespace TaskManament.Mvc.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Models.ApplicationUser> ApplicationUser { get; set; } = null!;
        public DbSet<Models.Tenant> Tenant { get; set; } = null!;
        public DbSet<Models.TenantMember> TenantMember { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationUser>(Models.ApplicationUser.Configure);
            modelBuilder.Entity<Models.Tenant>(Models.Tenant.Configure);
            modelBuilder.Entity<Models.TenantMember>(Models.TenantMember.Configure);
        }
    }

}
