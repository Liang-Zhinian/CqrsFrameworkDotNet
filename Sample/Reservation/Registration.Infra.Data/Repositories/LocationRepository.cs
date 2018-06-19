using System;
using System.Linq;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Repositories
{
    public class LocationRepository : ReadDbRepository<Location>, ILocationRepository
    {
        public LocationRepository(ReservationDbContext context):base(context){}

        //public Staff GetByEmail(string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
