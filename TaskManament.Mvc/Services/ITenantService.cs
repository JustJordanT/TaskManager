using System.Security.Claims;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public interface ITenantService
    {
        //Task<int> GetTenantIdAsync();
        //Task<bool> IsTenantMemberAsync(int tenantId, int userId);

        Task<Tenant> CreateTenantAsync(Tenant tenant, ClaimsPrincipal principal, CancellationToken token);
        //Task<Tenant> GetTenantAsync(int tenantId);
        Task<IEnumerable<Tenant>> GetTenantsAsync();

        Task<IEnumerable<Tenant>> GetTenantsByEmailAsync(string Email, CancellationToken token);
    }
}
