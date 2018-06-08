using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
using MAR.Domain.Events.Locations;
using MAR.Domain.Models.Employees;

namespace MAR.Domain.Models.Locations
{
    public class Location : AggregateRoot
    {
        public Guid BusinessID { get; private set; }
        public Guid SiteID { get; private set; }
        public string BusinessDescription { get; private set; }
        public List<LocationImage> AdditionalImageURLs { get; private set; }
        public int FacilitySquareFeet { get; private set; }
        public int TreatmentRooms { get; private set; }
        public bool ProSpaFinderSite { get; private set; }
        public bool HasClasses { get; private set; }
        public string PhoneExtension { get; private set; }
        public ActionCode Action { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public float Tax1 { get; private set; }
        public float Tax2 { get; private set; }
        public float Tax3 { get; private set; }
        public float Tax4 { get; private set; }
        public float Tax5 { get; private set; }
        public string Phone { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double DistanceInMiles { get; private set; }
        public string ImageURL { get; private set; }
        public string Description { get; private set; }
        /// Whether the location has a site that is available to consumers
        public bool HasSite { get; private set; }
        /// Whether the location can have classes reserved / appointments booked
        public bool CanBook { get; private set; }

        public List<Employee> Employees { get; private set; }

        public Location()
        {
        }

        public Location(Guid id, string name, string phone, string phoneExtension="")
        {
            Id = id;
            Name = name;
            Phone = phone;
            PhoneExtension = phoneExtension;

            Employees = new List<Employee>();

            // to do: apply location created event
            ApplyChange(new LocationCreatedEvent(Id, name, phone, phoneExtension));
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);

            ApplyChange(new EmployeeAssignedToLocationEvent(Id, this, employee));
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);

            ApplyChange(new EmployeeRemovedFromLocationEvent(Id, this, employee));
        }
    }
}
