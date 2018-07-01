using System;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface ITenantRepository: IReadDbRepository<Tenant>
    {
        //Staff GetByEmail(string email);
    }
}
