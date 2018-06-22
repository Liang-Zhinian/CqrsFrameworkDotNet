using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils;
using Business.Domain.Models.ValueObjects;
using Business.Contracts.Events.Security.Locations;

namespace Business.Domain.Models.Security
{
    public class Location : AggregateRoot
    {
        private Location(){}
        
        public Location(TenantId tenantId,
                       Guid businessId, string businessDescription,
                       string name, string description, string image, string primaryTelephone,
                        string secondaryTelephone, PostalAddress postalAddress)
        {
            this.Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.BusinessID = businessId;
            this.BusinessDescription = businessDescription;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
            this.PostalAddress = postalAddress;

            ApplyChange(new LocationCreatedEvent(
                                this.Id,
                                Guid.Parse(this.TenantId.Id),
                                businessId,
                                businessDescription,
                                name,
                                description,
                                image,
                                primaryTelephone,
                                secondaryTelephone,
                                postalAddress.StreetAddress,
                                postalAddress.StreetAddress2,
                                postalAddress.City,
                                postalAddress.StateProvince,
                                postalAddress.PostalCode,
                                postalAddress.CountryCode
                            )
                       );
        }

        public Guid BusinessID { get; private set; }

        public string BusinessDescription { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public LocationAddress Address { get; private set; }

        public TenantId TenantId { get; private set; }
        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        //public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }


        public void AddImage(LocationImage image){
            if (AdditionalLocationImages == null)
                AdditionalLocationImages = new List<LocationImage>();
            
            this.AdditionalLocationImages.Add(image);
        }

        public void AssignStaff(Staff staff)
        {
            if (StaffLoginLocations == null)
                StaffLoginLocations = new List<StaffLoginLocation>();

            StaffLoginLocation staffLoginLocation = new StaffLoginLocation(staff, this);

            this.StaffLoginLocations.Add(staffLoginLocation);
        }

        public void AssignResource(Resource resource)
        {
            if (ResourceLocations == null)
                ResourceLocations = new List<ResourceLocation>();

            ResourceLocation resourceLocation = new ResourceLocation(resource, this);

            this.ResourceLocations.Add(resourceLocation);
        }

        public void Apply(LocationCreatedEvent message){
            this.Id = message.Id;
            this.TenantId = new TenantId(message.TenantId.ToString());
            this.BusinessID = message.BusinessID;
            this.BusinessDescription = message.BusinessDescription;
            this.Name = message.Name;
            this.Description = message.Description;
            this.Image = message.Image;
            this.PrimaryTelephone = message.PrimaryTelephone;
            this.SecondaryTelephone = message.SecondaryTelephone;
            this.PostalAddress = new PostalAddress(message.StreetAddress,
                                                   message.StreetAddress2,
                                                   message.City,
                                                   message.StateProvince,
                                                   message.PostalCode,
                                                   message.CountryCode);
        }
    }
}
