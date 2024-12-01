using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManament.Mvc.Data;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserService(ApplicationDbContext context) { _context = context; }


        public async Task<ApplicationUser> CaptureApplicationUser(ClaimsPrincipal principal, CancellationToken token)
        {
            var claims = principal.Claims;
            var userId = principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value
                          ?? throw new ArgumentNullException(nameof(principal), "User ID claim is missing.");
            
            var displayName = principal.FindFirst("name")?.Value
                              ?? throw new ArgumentNullException(nameof(principal), "Display name claim is missing.");
            
            var email = principal.FindFirst("preferred_username")?.Value
                        ?? throw new ArgumentNullException(nameof(principal), "Email claim is missing.");

            var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.EntraID == userId, cancellationToken: token);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    EntraID = userId,
                    DisplayName = displayName,
                    Email = email
                };

                await _context.ApplicationUser.AddAsync(user, token);
                await _context.SaveChangesAsync(token);
            }

            return user;
        }

        public async Task<int> GetApplicationUserIdByEmail(string email, CancellationToken token)
        {
            try { 
            
            var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Email == email, cancellationToken: token);
            return user.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public int GetDefaultTenant(string email, CancellationToken token)
        {
            int tenantId = _context.ApplicationUser.FirstOrDefault(u => u.Email == email).DefaultTenant;
            return tenantId;
        }

        public async Task<bool> SetApplicationUserDefatulTenant(int tenantId, string email, CancellationToken token)
        {
            var userId = await GetApplicationUserIdByEmail(email, token);
            var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId, token);
            if (user != null)
            {
                user.DefaultTenant = tenantId;
                await _context.SaveChangesAsync(token);
            }
            return true;
        }
    }
}