using System;
using Business.Domain.Models.Security;

namespace Business.Domain.Repositories.Interfaces
{
    public interface ITenantRepository: IDomainRepository<Tenant>
    {
        //Staff GetByEmail(string email);
    }
}
