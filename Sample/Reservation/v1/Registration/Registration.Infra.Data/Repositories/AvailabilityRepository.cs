using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure.Repositories
{
    public class AvailabilityRepository : ReadDbRepository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(ReservationDbContext context) : base(context) { }

    }
}
