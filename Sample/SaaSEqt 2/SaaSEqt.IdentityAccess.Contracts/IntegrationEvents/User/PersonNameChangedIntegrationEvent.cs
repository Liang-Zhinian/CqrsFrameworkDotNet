﻿using System;
using CqrsFramework.Events;
using SaaSEqt.IdentityAccess.Domain.Identity.Entities;

namespace SaaSEqt.IdentityAccess.Contracts.IntegrationEvents.User
{
    public class PersonNameChangedIntegrationEvent : IEvent
    {
        public PersonNameChangedIntegrationEvent(
            TenantId tenantId,
                Guid userId,
                String username,
                FullName name)
        {
            this.Name = name;
            this.TenantId = tenantId.Id;
            this.Username = username;

            this.Id = userId;
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public FullName Name { get; set; }

        public string TenantId { get; set; }

        public string Username { get; set; }
    }
}
