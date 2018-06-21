using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class ServiceCategoryRepository : ReadDbRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ReservationDbContext context) : base(context) { }
    }
}
