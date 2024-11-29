using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public interface ITenantService
    {
        //Task<int> GetTenantIdAsync();
        //Task<bool> IsTenantMemberAsync(int tenantId, int userId);

        Task<Tenant> CreateTenantAsync(Tenant tenant);
        //Task<Tenant> GetTenantAsync(int tenantId);
        Task<IEnumerable<Tenant>> GetTenantsAsync();
    }
}
