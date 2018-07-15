using System;
using Business.Domain.Identity.Entities;
using Business.Domain.SeedWork;

namespace Business.Domain.Identity.Repositories
{
    public interface IStaffRepository: IDomainRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
