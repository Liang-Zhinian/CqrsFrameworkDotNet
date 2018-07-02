using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class ServiceItemRepository : ReadDbRepository<ServiceItem>, IServiceItemRepository
    {
        public ServiceItemRepository(ReservationDbContext context) : base(context) { }
    }
}
