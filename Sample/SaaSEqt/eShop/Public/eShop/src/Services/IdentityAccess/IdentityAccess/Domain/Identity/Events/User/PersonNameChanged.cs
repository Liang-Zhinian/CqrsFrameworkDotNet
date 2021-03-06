﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Identity.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Identity.Events.User
{
    public class PersonNameChanged : IDomainEvent
    {
        public PersonNameChanged(
            Guid tenantId,
            Guid userId,
                String username,
                FullName name)
        {
            this.Name = name;
            this.TenantId = tenantId;
            this.UserId = userId;
            this.Username = username;

            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public Guid UserId { get; set; }

        public FullName Name { get; private set; }

        public Guid TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
