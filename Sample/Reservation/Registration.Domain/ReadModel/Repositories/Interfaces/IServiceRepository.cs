using System;
using Business.Domain.Models;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IServiceRepository: IReadDbRepository<Service>
    {
        //Staff GetByEmail(string email);
    }
}
