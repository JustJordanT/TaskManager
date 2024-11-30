using Microsoft.EntityFrameworkCore;
using TaskManament.Mvc.Data;
using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public class TenantMemberService : ITenantMemberService
    {
        public readonly ApplicationDbContext _context;

        public TenantMemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddTenantMember(int TenantId, int ApplicationUserId, CancellationToken token)
        {
            var tenantMember = new Models.TenantMember
            {
                TenantId = TenantId,
                UserId = ApplicationUserId
            };

            await _context.TenantMember.AddAsync(tenantMember, token);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TenantMember>> GetTenantMembersByUserIdAsync(int Id, CancellationToken token)
        {
            return await _context.TenantMember.Where(x => x.UserId == Id).ToListAsync(token);
        }
    }
}
