using TaskManament.Mvc.Data;

namespace TaskManament.Mvc.Services
{
    public class TenantMember : ITenantMember
    {
        public readonly ApplicationDbContext _context;

        public TenantMember(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TenantMember> AddTenantMember(TenantMember tenantMember)
        {
           await _context.TenantMember.Add(tenantMember);
            _context.SaveChanges();
            return tenantMember;
        }
    }
}
