using System;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface ILocationRepository: IReadDbRepository<Location>
    {
        //Staff GetByEmail(string email);
    }
}
