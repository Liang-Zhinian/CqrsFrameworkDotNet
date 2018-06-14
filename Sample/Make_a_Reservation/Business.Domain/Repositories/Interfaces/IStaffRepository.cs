using System;
using Business.Domain.Models.Security;

namespace Business.Domain.Repositories.Interfaces
{
    public interface IStaffRepository: IDomainRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
