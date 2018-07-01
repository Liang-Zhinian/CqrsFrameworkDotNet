using System;
using Registration.Domain.ReadModel;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IServiceRepository: IReadDbRepository<Service>
    {
        //Staff GetByEmail(string email);
    }
}
