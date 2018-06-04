﻿using CqrsFramework.Domain;
// using MAR.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain
{
    public class Business : AggregateRoot
    {
        private Guid _businessId;

        private Business() { }

        public Business(Guid id, Guid businessId)
        {
            Id = id;
            _businessId = businessId;

            // ApplyChange(new EmployeeCreatedEvent(id, employeeID, firstName, lastName, dateOfBirth, jobTitle));
        }
    }
}
