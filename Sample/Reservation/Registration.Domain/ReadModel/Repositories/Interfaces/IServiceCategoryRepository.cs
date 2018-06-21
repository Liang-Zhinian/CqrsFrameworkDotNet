using System;
using Registration.Domain.ReadModel;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IServiceCategoryRepository: IReadDbRepository<ServiceCategory>
    {
        //Staff GetByEmail(string email);
    }
}
