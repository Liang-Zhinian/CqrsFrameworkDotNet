using System;
using System.Linq;
using System.Collections.Generic;

namespace SaaSEqt.BizInfo
{
    public class BizInfoService
    {
        private BizInfoDbContext context;

        public BizInfoService(BizInfoDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Location> FindLocations(Guid tenantId){
            return this.context.Set<Location>().Where(_ => _.TenantId.Equals(tenantId));
        }

        public Location FindLocation(Guid locationId)
        {
            return this.context.Set<Location>().Find(locationId);
        }
    }
}
