using System;
using Business.Domain.Models.Security;

namespace Business.Domain.Repositories.Interfaces
{
    public interface ITenantRepository: IReadDbRepository<Tenant>
    {
        //Staff GetByEmail(string email);
    }
}
