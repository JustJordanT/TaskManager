using System.Security.Claims;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public interface IApplicationUserService
    {

        public Task<ApplicationUser> CaptureApplicationUser(ClaimsPrincipal principal, CancellationToken token);
    }
}
