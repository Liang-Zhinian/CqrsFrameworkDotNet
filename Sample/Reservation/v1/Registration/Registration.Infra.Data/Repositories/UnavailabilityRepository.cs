using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure.Repositories
{
    public class UnavailabilityRepository : ReadDbRepository<Unavailability>, IUnavailabilityRepository
    {
        public UnavailabilityRepository(ReservationDbContext context) : base(context) { }

    }
}
