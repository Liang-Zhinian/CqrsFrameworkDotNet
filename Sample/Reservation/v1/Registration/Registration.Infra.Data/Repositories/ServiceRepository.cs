using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class ServiceRepository : ReadDbRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ReservationDbContext context) : base(context) { }
    }
}
