using System;
using CqrsFramework.Domain;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;

namespace SaaSEqt.eShop.Site.Api.Model
{
    public class LocationService
    {
        private readonly SiteDbContext _context;

        public LocationService(SiteDbContext context)
        {
            _context = context;
        }

    }
}
