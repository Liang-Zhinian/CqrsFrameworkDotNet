﻿using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Business.Domain.Commands.Security.Tenants;
using Business.Domain.Models.Security;
using MediatR;

namespace Business.Domain.CommandHandlers.Security
{
    public class TenantCommandHandler : CommandHandler, 
                                        ICommandHandler<CreateTenantCommand>
    {
        
        public TenantCommandHandler(ISession session):base(session)
        {
        }

        public void Handle(CreateTenantCommand message)
        {
            Tenant tenant = new Tenant(message.Id, message.Name, message.DisplayName, message.TenantContact, message.TenantAddress);

            AddToSession(tenant);
            CommitSession();
        }
    }
}