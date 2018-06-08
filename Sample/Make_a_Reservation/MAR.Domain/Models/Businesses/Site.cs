using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
using MAR.Domain.Events.Locations;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Locations;

namespace MAR.Domain.Models.Businesses
{
    public class Site : AggregateRoot
    {
        public string Name { get; private set; } = "Book2";
        public string Description { get; private set; } = "Book2";
        public string LogoURL { get; private set; } = "Book2";
        public string PageColor1 { get; private set; } = "#3da0e0";
        public string PageColor2 { get; private set; } = "#98ba81";
        public string PageColor3 { get; private set; } = "#ffffff";
        public string PageColor4 { get; private set; }
        public bool AcceptsVisa { get; private set; } = true;
        public bool AcceptsDiscover { get; private set; } = false;
        public bool AcceptsMasterCard { get; private set; } = true;
        public bool AcceptsAmericanExpress { get; private set; } = false;
        public string ContactEmail { get; private set; } = "";
        public bool ESA { get; private set; } = false;
        public bool TotalWOD { get; private set; } = true;
        public bool TaxInclusivePrices { get; private set; } = true;

        public List<Location> Locations { get; private set; }
        public List<Employee> Employees { get; private set; }

        public Site()
        {
            
        }

        public Site(Guid id, string name, string description){
            
            // to do: apply site created event
            ApplyChange(new SiteCreatedEvent(Id, name, description));
        }

        public void AddLocation(Location location)
        {
            ApplyChange(new LocationAssignedToSiteEvent(Id, this, location));
        }

        public void RemoveLocation(Location location)
        {
            ApplyChange(new LocationRemovedFromSiteEvent(Id, this, location));
        }

        public void AddEmployee(Employee employee)
        {
            ApplyChange(new EmployeeAssignedToSiteEvent(Id, this, employee));
        }

        public void RemoveEmployee(Employee employee)
        {
            ApplyChange(new EmployeeRemovedFromSiteEvent(Id, this, employee));
        }

        public void Apply(SiteCreatedEvent message){
            Name = message.Name;
            Description = message.Description;
        }

        public void Apply(LocationAssignedToSiteEvent message) { 
            Locations.Add(message.Location);
        }

        public void Apply(LocationRemovedFromSiteEvent message) {
            Locations.Remove(message.Location);}

        public void Apply(EmployeeAssignedToSiteEvent message) { 
            Employees.Add(message.Employee);
        }

        public void Apply(EmployeeRemovedFromSiteEvent message) { 
            Employees.Remove(message.Employee);
        }
    }
}
