namespace MAR.Application.ReadModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("employee")]
    public partial class Employee
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee(Guid id, string firstName, string lastName, DateTime dob, string jobTitle)
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