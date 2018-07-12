using System;
using FluentValidation.Results;
//using MediatR;

namespace Registration.Contracts.Commands
{
    public abstract class BaseCommand //, IRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();

        public string MessageType { get; set; }
    }
}
