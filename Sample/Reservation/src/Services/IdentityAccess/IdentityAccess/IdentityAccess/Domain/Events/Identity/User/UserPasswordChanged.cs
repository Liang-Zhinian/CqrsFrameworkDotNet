﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.User
{
    public class UserPasswordChanged : IDomainEvent
    {
        public UserPasswordChanged(
                TenantId tenantId,
                String username)
        {
            this.TenantId = tenantId.Id;
            this.Username = username;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
