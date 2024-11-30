using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManament.Mvc.Data;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITenantMemberService _tenantMemberService;
        private readonly IApplicationUserService _applicationUserService;

        public TenantService(
            ITenantMemberService tenantMemberService,
            IApplicationUserService applicationUserService,
            ApplicationDbContext context
            )
        {
            _context = context;
            _tenantMemberService = tenantMemberService;
            _applicationUserService = applicationUserService;
        }

        public async Task<Tenant> CreateTenantAsync(Tenant tenant, ClaimsPrincipal principal, CancellationToken token)
        {
            var email = principal.FindFirst("preferred_username")?.Value
                        ?? throw new ArgumentNullException(nameof(principal), "Email claim is missing.");

            Console.WriteLine($"User Email: {email}");

            var userId = await _applicationUserService.GetApplicationUserByEmail(email, token);

            Console.WriteLine($"UserID: {userId}");

            await _context.Tenant.AddAsync(tenant, token);
            await _context.SaveChangesAsync(token);

            _tenantMemberService.AddTenantMember(tenant.Id, userId, token);
            await _context.SaveChangesAsync(token);
            return tenant;
        }

        public async Task<IEnumerable<Tenant>> GetTenantsAsync()
        {
            return await _context.Tenant.ToListAsync();
        }

        public async Task<IEnumerable<Tenant>> GetTenantsByEmailAsync(string email, CancellationToken token)
        {
            var tenants = new List<Tenant>();

            var userId = await _applicationUserService.GetApplicationUserByEmail(email, token);

            var tenantMembers = await _tenantMemberService.GetTenantMembersByUserIdAsync(userId, token);

            foreach (var tenantMember in tenantMembers)
            {
                var tenant = await _context.Tenant.FirstOrDefaultAsync(t => t.Id == tenantMember.TenantId, token);
                tenants.Add(tenant);
            }
            return tenants;
        }
    }
}
