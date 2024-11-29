using Microsoft.EntityFrameworkCore;
using TaskManament.Mvc.Data;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public class TenantService(ApplicationDbContext context) : ITenantService
    {
        public readonly ApplicationDbContext _context = context;

        public async Task<Tenant> CreateTenantAsync(Tenant tenant)
        {
            await _context.Tenant.AddAsync(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }

        public async Task<IEnumerable<Tenant>> GetTenantsAsync()
        {
            return await _context.Tenant.ToListAsync();
        }
    }
}
