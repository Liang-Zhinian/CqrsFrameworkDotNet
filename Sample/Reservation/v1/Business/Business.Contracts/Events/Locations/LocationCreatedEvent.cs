using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationCreatedEvent : BaseEvent, IEvent
    {
        protected LocationCreatedEvent()
        {

        }

        public LocationCreatedEvent(
            Guid id,
            Guid siteId,
            string name,
            string description,
            string contactName,
            string emailAddress,
            string primaryTelephone,
            string secondaryTelephone)
        {
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
            this.Id = id;
            this.SiteId = siteId;
            this.Name = name;
            this.Description = description;
            this.ContactName = contactName;
            this.EmailAddress = emailAddress;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
        }

        //public LocationCreatedEvent(
        //    Guid id,
        //    Guid siteId,
        //    string streetAddress,
        //    string streetAddress2,
        //    string city,
        //    string stateProvince,
        //    string postalCode,
        //    string countryCode)
        //    :base(
        //        id,
        //        siteId,
        //        streetAddress,
        //        streetAddress2,
        //        city,
        //        stateProvince,
        //        postalCode,
        //        countryCode)
        //{
        //    Version = 1;
        //    TimeStamp = DateTimeOffset.Now;
        //}

        public Guid SiteId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }

        public string EmailAddress { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }
    }
}
