namespace MAR.Application.ReadModel.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EmployeeDto
    {
        public EmployeeDto(Guid id, string firstName, string lastName, DateTime dob, string jobTitle)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            JobTitle = jobTitle;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
}