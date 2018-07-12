using System;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class AvailabilityRepository : ReadDbRepository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(ReservationDbContext context) : base(context) { }

    }
}
