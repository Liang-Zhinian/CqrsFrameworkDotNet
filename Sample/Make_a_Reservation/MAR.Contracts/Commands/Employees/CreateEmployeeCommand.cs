using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAR.Contracts.Commands.Employees
{
public class CreateEmployeeCommand : BaseCommand
{
    public readonly Guid EmployeeID;
    public readonly string FirstName;
    public readonly string LastName;
    public readonly DateTime DateOfBirth;
    public readonly string JobTitle;

        public CreateEmployeeCommand(Guid id, Guid employeeID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
    {
        Id = id;
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        JobTitle = jobTitle;
    }
}
}