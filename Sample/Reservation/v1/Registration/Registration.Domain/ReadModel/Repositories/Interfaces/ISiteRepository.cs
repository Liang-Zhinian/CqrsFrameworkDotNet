using System;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface ISiteRepository: IReadDbRepository<Site>
    {
        //Staff GetByEmail(string email);
    }
}
