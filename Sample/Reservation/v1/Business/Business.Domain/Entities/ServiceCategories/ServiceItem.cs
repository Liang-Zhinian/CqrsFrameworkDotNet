using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Business.Contracts.Events.ServiceCategory;
using Business.Domain.Entities.Schedules;
using CqrsFramework.Domain;

namespace Business.Domain.Entities.ServiceCategories
{
    public class ServiceItem // : AggregateRoot
    {
        private ServiceItem()
        {
            Id = Guid.NewGuid();
        }

        public ServiceItem(Guid siteId, string name, string description, int defaultTimeLength, double price, Guid serviceCategoryId, int industryStandardCategoryId)
            : this()
        {
            SiteId = siteId;
            Name = name;
            Description = description;
            DefaultTimeLength = defaultTimeLength;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
            IndustryStandardCategoryId = industryStandardCategoryId;


            //var serviceItemCreatedEvent = new ServiceItemCreatedEvent(Id,
            // name,
            // description,
            // defaultTimeLength,
            // price,
            // serviceCategoryId,
            // siteId,
            // industryStandardCategoryId
            //);
            //ApplyChange(serviceItemCreatedEvent);
        }

        #region public properties

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int DefaultTimeLength { get; private set; }

        //public Guid ProgramId { get; private set; }
        //public virtual Program Program { get; private set; }

        //public int NumDeducted { get; private set; }

        //public ActionCode Action { get; private set; }

        public Guid ServiceCategoryId { get; private set; }
        public virtual ServiceCategory ServiceCategory { get; private set; }

        public int IndustryStandardCategoryId { get; private set; }
        public virtual IndustryStandardCategory IndustryStandardCategory { get; private set; }

        public double Price { get; private set; }

        public bool AllowOnline { get; private set; }

        //public double TaxRate { get; private set; }

        //public double TaxAmount => Price * TaxRate;

        //public Guid LocationId { get; private set; }
        //public virtual Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public virtual ICollection<Availability> Availibilities { get; private set; }
        public virtual ICollection<Unavailability> Unavailabilities { get; private set; }

        #endregion

        #region [Command Methods]

        public Availability AddAvailability(Guid staffId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, DateTime bookableEndTime)
        {
            Availability availability = new Availability(this.SiteId, staffId, this.Id, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, bookableEndTime);

            if (Availibilities == null) Availibilities = new ObservableCollection<Availability>();

            Availibilities.Add(availability);

            return availability;
        }

        public Unavailability AddUnavailability(Guid staffId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
        {
            Unavailability unavailability = new Unavailability(this.SiteId, staffId, this.Id, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, description);

            if (Unavailabilities == null) Unavailabilities = new ObservableCollection<Unavailability>();

            Unavailabilities.Add(unavailability);

            return unavailability;
        }


        #endregion
    }
}
