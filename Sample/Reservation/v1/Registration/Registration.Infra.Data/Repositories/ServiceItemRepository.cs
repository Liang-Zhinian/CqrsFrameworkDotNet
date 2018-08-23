using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure.Repositories
{
    public class ServiceItemRepository : ReadDbRepository<ServiceItem>, IServiceItemRepository
    {
        public ServiceItemRepository(ReservationDbContext context) : base(context) { }
    }
}
