using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class UnavailabilityRepository : ReadDbRepository<Unavailability>, IUnavailabilityRepository
    {
        public UnavailabilityRepository(ReservationDbContext context) : base(context) { }

    }
}
