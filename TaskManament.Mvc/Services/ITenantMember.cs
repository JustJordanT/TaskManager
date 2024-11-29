namespace TaskManament.Mvc.Services
{
    public interface ITenantMember
    {
        public Task<TenantMember> AddTenantMember(TenantMember tenantMember);
        //public void RemoveTenantMember();
    }
}
