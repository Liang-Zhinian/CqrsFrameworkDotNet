using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils;
using Business.Contracts.Events.Locations;
using System.Collections.ObjectModel;

namespace Business.Domain.Entities
{
    public class Location : AggregateRoot
    {
        #region ctors

        private Location(){}

        public Location(TenantId tenantId,
                        Guid siteId,
                        string name, 
                        string description, 
                        byte[] image, 
                        ContactInformation contactInformation)
        {
            this.Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.SiteId = siteId;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.ContactInformation = contactInformation;
            this.PostalAddress = new PostalAddress("", "", "", "", "", "");
            this.Geolocation = new Geolocation(null, null);
            this.AdditionalLocationImages = new ObservableCollection<LocationImage>();

            ApplyChange(new LocationCreatedEvent(
                                this.Id,
                                Guid.Parse(this.TenantId.Id),
                                siteId,
                                name,
                                description,
                                image,
                                contactInformation.PrimaryTelephone,
                                contactInformation.SecondaryTelephone
                            )
                       );
        }

        #endregion

        #region public properties

        public string Name { get; private set; }

        public string Description { get; private set; }

        public byte[] Image { get; private set; }

        public ContactInformation ContactInformation { get; private set; }

        //public Guid? LocationAddressId { get; private set; }
        public PostalAddress PostalAddress { get; private set; }

        public Geolocation Geolocation { get; set; }

        public TenantId TenantId { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        //public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }

        #endregion

        public void AddImage(LocationImage image){
            if (AdditionalLocationImages == null)
                AdditionalLocationImages = new List<LocationImage>();
            
            this.AdditionalLocationImages.Add(image);
        }

        public void AssignStaff(Staff staff)
        {
            if (StaffLoginLocations == null)
                StaffLoginLocations = new List<StaffLoginLocation>();

            StaffLoginLocation staffLoginLocation = new StaffLoginLocation(this.TenantId, this.SiteId, staff.Id, this.Id);

            this.StaffLoginLocations.Add(staffLoginLocation);
        }

        public void ChangeAddress(PostalAddress postalAddress){
            this.PostalAddress = postalAddress;

            ApplyChange(new LocationAddressChangedEvent(this.Id, Guid.Parse(this.TenantId.Id), this.SiteId, postalAddress.StreetAddress,
                                                        postalAddress.StreetAddress2, postalAddress.City,
                                                        postalAddress.StateProvince, postalAddress.PostalCode,
                                                        postalAddress.CountryCode));
        }

        //public void AssignResource(Resource resource)
        //{
        //    if (ResourceLocations == null)
        //        ResourceLocations = new List<ResourceLocation>();

        //    ResourceLocation resourceLocation = new ResourceLocation(resource, this);

        //    this.ResourceLocations.Add(resourceLocation);
        //}

        //public void Apply(LocationCreatedEvent message){
            //this.Id = message.Id;
            //this.TenantId = new TenantId(message.TenantId.ToString());
            //this.Name = message.Name;
            //this.Description = message.Description;
            //this.Image = message.Image;
            //this.Phone = message.PrimaryTelephone;
            //this.SecondaryTelephone = message.SecondaryTelephone;
            //this.PostalAddress = new PostalAddress(message.StreetAddress,
                                                   //message.StreetAddress2,
                                                   //message.City,
                                                   //message.StateProvince,
                                                   //message.PostalCode,
                                                   //message.CountryCode);
        //}
    }
}
