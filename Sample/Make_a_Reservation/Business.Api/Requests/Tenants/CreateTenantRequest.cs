
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Api.Requests.Tenants
{
    public class CreateTenantRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }
    }

    //public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    //{
    //    public CreateEmployeeRequestValidator(IEmployeeRepository employeeRepo, ILocationRepository locationRepo)
    //    {
    //        RuleFor(x => x.EmployeeID).Must(x => !employeeRepo.Exists(x)).WithMessage("An Employee with this ID already exists.");
    //        RuleFor(x => x.LocationID).Must(x => locationRepo.Exists(x)).WithMessage("No Location with this ID exists.");
    //        RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("The First Name cannot be blank.");
    //        RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("The Last Name cannot be blank.");
    //        RuleFor(x => x.JobTitle).NotNull().NotEmpty().WithMessage("The Job Title cannot be blank.");
    //        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Today.AddYears(-16)).WithMessage("Employees must be 16 years old or older.");
    //    }
    //}
}
