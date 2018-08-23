using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure.Repositories
{
    public class ServiceCategoryRepository : ReadDbRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ReservationDbContext context) : base(context) { }
    }
}
