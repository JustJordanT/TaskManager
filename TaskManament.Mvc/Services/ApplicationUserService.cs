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
            // cw out the cliam types
            var claims = principal.Claims;
            foreach (var claim in claims)
            {
                Console.WriteLine($"Type: {claim.Type} Value: {claim.Value}");
            }

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
    }
}