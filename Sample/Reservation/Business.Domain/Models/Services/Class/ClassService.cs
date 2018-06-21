using System;
namespace Business.Domain.Models.Services.Classs
{
    public class ClassService : Service
    {
        public ClassService(TenantId tenantId, Guid categoryId, string name, string description) 
            : base(tenantId, categoryId, name, description)
        {
        }
    }
}
