using System.Security.Claims;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public interface IApplicationUserService
    {

        public Task<ApplicationUser> CaptureApplicationUser(ClaimsPrincipal principal, CancellationToken token);
        public Task<int> GetApplicationUserIdByEmail(string email, CancellationToken token);

        public Task<bool> SetApplicationUserDefatulTenant(int tenantId, string email, CancellationToken token);

        public int GetDefaultTenant(string email, CancellationToken token);
    }
}
