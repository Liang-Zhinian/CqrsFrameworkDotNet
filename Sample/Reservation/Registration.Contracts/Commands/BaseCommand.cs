using CqrsFramework.Commands;
using System;
using FluentValidation.Results;
//using MediatR;

namespace Registration.Contracts.Commands
{
    public abstract class BaseCommand : ICommand//, IRequest
    {
        /// <summary>
        /// The Aggregate ID of the Aggregate Root being changed
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Expected Version which the Aggregate will become.
        /// </summary>
        public int ExpectedVersion { get; set; }

        //public Tenant Tenant { get; private set; }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public string MessageType { get; set; }

        protected BaseCommand()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().FullName;
        }

        public abstract bool IsValid();
    }
}
