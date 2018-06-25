using System;
using System.Collections.Generic;
using Registration.Domain.ReadModel.Security;

namespace Registration.Application.Interfaces
{
    public interface ISiteService
    {
        IEnumerable<Site> FindSites();
    }
}
