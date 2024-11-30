using TaskManament.Mvc.Models;

namespace TaskManament.Mvc.Services
{
    public interface ITenantMemberService
    {
        public void AddTenantMember(int TenantId, int ApplicationUserId, CancellationToken token);
        public Task<IEnumerable<TenantMember>> GetTenantMembersByUserIdAsync(int Id, CancellationToken token);
        //public void RemoveTenantMember();
    }
}
