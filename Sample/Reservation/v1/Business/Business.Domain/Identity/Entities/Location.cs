using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Contracts.Events.Locations;
using System.Collections.ObjectModel;

namespace Business.Domain.Entities
{
    public class Location // : AggregateRoot
    {
        #region ctors

        private Location(){}

        public Location(Guid siteId,
                        string name, 
                        string description,
                        ContactInformation contactInformation)
        {
			this.Id = Guid.NewGuid();
            this.SiteId = siteId;
            this.Name = name;
            this.Description = description;
            this.Image = null;
            this.ContactInformation = contactInformation;
            this.PostalAddress = new PostalAddress("", "", "", "", "", "");
            this.Geolocation = new Geolocation(null, null);
            this.AdditionalLocationImages = new ObservableCollection<LocationImage>();


            //ApplyChange(new LocationCreatedEvent(
                       //         this.Id,
                       //         siteId,
                       //         name,
                       //         description,
                       //         contactInformation.ContactName,
                       //         contactInformation.EmailAddress,
                       //         contactInformation.PrimaryTelephone,
                       //         contactInformation.SecondaryTelephone
                       //     )
                       //);
        }

        #endregion

        #region public properties

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public byte[] Image { get; private set; }

        public ContactInformation ContactInformation { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public Geolocation Geolocation { get; set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        //public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }

        #endregion

        #region [Command Methods which Publish Domain Events]

        public void AddImage(LocationImage image){
            if (AdditionalLocationImages == null)
                AdditionalLocationImages = new List<LocationImage>();
            
            this.AdditionalLocationImages.Add(image);

            //ApplyChange(new AdditionalLocationImageCreatedEvent(image.Id, image.SiteId, this.Id, image.Image));
        }

        public void AssignStaff(Staff staff)
        {
            if (StaffLoginLocations == null)
                StaffLoginLocations = new List<StaffLoginLocation>();

            StaffLoginLocation staffLoginLocation = new StaffLoginLocation(this.SiteId, staff.Id, this.Id);

            this.StaffLoginLocations.Add(staffLoginLocation);
        }

        public void ChangeAddress(PostalAddress postalAddress){
            this.PostalAddress.StreetAddress = postalAddress.StreetAddress;
            this.PostalAddress.StreetAddress2 = postalAddress.StreetAddress2;
            this.PostalAddress.City = postalAddress.City;
            this.PostalAddress.StateProvince = postalAddress.StateProvince;
            this.PostalAddress.PostalCode = postalAddress.PostalCode;
            this.PostalAddress.CountryCode = postalAddress.CountryCode;

            //ApplyChange(new LocationAddressChangedEvent(this.Id, this.SiteId, postalAddress.StreetAddress,
                                                        //postalAddress.StreetAddress2, postalAddress.City,
                                                        //postalAddress.StateProvince, postalAddress.PostalCode,
                                                        //postalAddress.CountryCode));
        }

        public void SetGeolocation(Geolocation geolocation)
        {
            this.Geolocation.Latitude = geolocation.Latitude;
            this.Geolocation.Longitude = geolocation.Longitude;

            //ApplyChange(new LocationGeolocationChangedEvent(this.Id, this.SiteId, geolocation.Latitude, geolocation.Longitude));
        }

        public void SetLocationImage(byte[] image)
        {
            this.Image = image;

            //ApplyChange(new LocationImageChangedEvent(this.Id, this.SiteId, image));
        }

        //public void AssignResource(Resource resource)
        //{
        //    if (ResourceLocations == null)
        //        ResourceLocations = new List<ResourceLocation>();

        //    ResourceLocation resourceLocation = new ResourceLocation(resource, this);

        //    this.ResourceLocations.Add(resourceLocation);
        //}

        #endregion

        #region [ Apply event methods ]

        public void Apply(LocationCreatedEvent message)
        {
            this.Name = message.Name;
            this.Description = message.Description;
            this.ContactInformation = new ContactInformation(message.ContactName,
                                                             message.PrimaryTelephone,
                                                             message.SecondaryTelephone,
                                                             message.EmailAddress);
            this.SiteId = message.SiteId;

        }

        public void Apply(LocationAddressChangedEvent message)
        {
            this.PostalAddress = new PostalAddress(message.StreetAddress,
                                                    message.StreetAddress2,
                                                    message.City,
                                                    message.StateProvince,
                                                    message.PostalCode,
                                                   message.CountryCode);

            this.SiteId = message.SiteId;
        }

        public void Apply(LocationImageChangedEvent message)
        {
            this.Image = message.Image;

            this.SiteId = message.SiteId;
        }

        public void Apply(LocationGeolocationChangedEvent message)
        {
            this.Geolocation = new Geolocation(message.Latitude, message.Longitude);

            this.SiteId = message.SiteId;
        }

        public void Apply(AdditionalLocationImageCreatedEvent message)
        {
            this.AdditionalLocationImages.Add(new LocationImage(this.SiteId, this.Id, message.Image));

            this.SiteId = message.SiteId;
        }


        #endregion
    }
}
