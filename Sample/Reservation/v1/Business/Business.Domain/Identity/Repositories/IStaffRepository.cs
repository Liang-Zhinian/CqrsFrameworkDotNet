using System;
using Business.Domain.Entities;

namespace Business.Domain.Repositories
{
    public interface IStaffRepository: IDomainRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
