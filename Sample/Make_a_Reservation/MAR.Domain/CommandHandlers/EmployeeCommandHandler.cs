using CqrsFramework.Commands;
using CqrsFramework.Domain;
using MAR.Domain.Commands.Employees;
using MAR.Domain.Models.Employees;
using MAR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAR.Domain.CommandHandlers
{
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly ISession _session;

        public EmployeeCommandHandler(ISession session)
        {
            _session = session;
        }

        public void Handle(CreateEmployeeCommand command)
        {
            //Employee employee = new Employee(command.Id, command.FirstName, command.LastName, command.DateOfBirth, command.JobTitle);
            //_session.Add(employee);
            //_session.Commit();
        }
    }
}