using System;
using System.Linq;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure.Repositories
{
    public class SiteRepository : ReadDbRepository<Site>, ISiteRepository
    {
        public SiteRepository(ReservationDbContext context):base(context){}

        //public Staff GetByEmail(string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
