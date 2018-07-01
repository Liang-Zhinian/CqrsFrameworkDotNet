using System;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IStaffRepository: IReadDbRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
