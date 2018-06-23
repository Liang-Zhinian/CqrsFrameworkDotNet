using System;
using Business.Domain.Models;

namespace Business.Domain.Repositories.Interfaces
{
    public interface IStaffRepository: IDomainRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
