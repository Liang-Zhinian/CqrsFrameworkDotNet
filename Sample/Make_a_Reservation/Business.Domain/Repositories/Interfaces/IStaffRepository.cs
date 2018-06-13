using System;
using Business.Domain.Models.Security;

namespace Business.Domain.Repositories.Interfaces
{
    public interface IStaffRepository: IReadDbRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
