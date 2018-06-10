using System;
using MAR.Domain.Models.Security;

namespace MAR.Domain.Repositories
{
    public interface IStaffRepository: IReadDbRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
