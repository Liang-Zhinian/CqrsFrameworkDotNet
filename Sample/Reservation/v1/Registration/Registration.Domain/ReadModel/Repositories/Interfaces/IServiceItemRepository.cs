using System;
using Registration.Domain.ReadModel;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IServiceItemRepository: IReadDbRepository<ServiceItem>
    {
        //Staff GetByEmail(string email);
    }
}
