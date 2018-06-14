﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Domain.Models.Security;

namespace Business.Domain.Repositories.Interfaces
{
    public interface ITenantRepository: IDomainRepository<Tenant>
    {
        void Register(Tenant tenant);

    }
}
