using System;
using FluentValidation;
using MAR.Domain.Commands.Security.Businesses;

namespace MAR.Domain.Validations.Security.Businesses
{
    public abstract class BusinessValidation<T> : AbstractValidator<T> where T : BusinessCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        //protected void ValidateBirthDate()
        //{
        //    RuleFor(c => c.BirthDate)
        //        .NotEmpty()
        //        .Must(HaveMinimumAge)
        //        .WithMessage("The customer must have 18 years or more");
        //}

        protected void ValidateEmail()
        {
            RuleFor(c => c.BusinessContact.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        //protected static bool HaveMinimumAge(DateTime birthDate)
        //{
        //    return birthDate <= DateTime.Now.AddYears(-18);
        //}
    }
}
