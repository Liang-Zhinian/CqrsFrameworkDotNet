using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain.Models
{
    public class Client : AggregateRoot
    {
        private Guid _clientId;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        private Client() { }

        public Client(Guid id, Guid clientId, string firstName, string lastName, DateTime dateOfBirth)
        {
            Id = id;
            _clientId = clientId;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;

            //ApplyChange(new EmployeeCreatedEvent(id, clientId, firstName, lastName, dateOfBirth, jobTitle));
        }
    }
}
