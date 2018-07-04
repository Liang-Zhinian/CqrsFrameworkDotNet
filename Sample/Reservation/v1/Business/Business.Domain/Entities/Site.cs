using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Business.Contracts.Events.Sites;
using CqrsFramework.Domain;

namespace Business.Domain.Entities
{
    public class Site : AggregateRoot
    {
        private Site()
        {
        }

        public Site(TenantId tenantId, string siteName, string siteDescription, bool active)
        {
            this.TenantId = tenantId;
            this.Id = Guid.NewGuid();
            this.Name = siteName;
            this.Description = siteDescription;
            this.Active = active;
            this.ContactInformation = new ContactInformation();
            this.Locations = new ObservableCollection<Location>();
            this.Staffs = new ObservableCollection<Staff>();

            //this.Branding = Branding.CreateDefaultBranding(tenantId, this);
            //this.BrandingId = this.Branding.Id;

            Locations = new ObservableCollection<Location>();

            ApplyChange(new SiteCreatedEvent(this.Id, siteName, siteDescription, active, tenantId.Id));
        }

        #region public properties

        //public Guid Id { get; private set; }

        /// The name of the site
        public string Name { get; private set; }
        /// Site description
        public string Description { get; private set; }

        public bool Active { get; private set; }

        //public Guid? BrandingId { get; private set; }
        public virtual Branding Branding { get; private set; }

        public ContactInformation ContactInformation { get; private set; }

        public virtual TenantId TenantId { get; private set; }

        public virtual ICollection<Location> Locations { get; private set; }
        public virtual ICollection<Staff> Staffs { get; private set; }

        #endregion

        #region public methods

        public Location ProvisionLocation(string name,
                        string description,
                        byte[] image,
                        ContactInformation contactInformation){
            Location location = new Location(this.Id, name, description, image, contactInformation);

            // To Do: send event
            if (Locations == null) Locations = new ObservableCollection<Location>();
            Locations.Add(location);

            return location;
        }

        public void CreateBranding(byte[] logo, string pageColor1, string pageColor2, string pageColor3, string pageColor4){
            this.Branding = new Branding(this.Id, logo, pageColor1, pageColor2, pageColor3, pageColor4);
            //return 
            // To Do: send event
        }

        public void ChangeContactInformation(string contactName, string primaryTelephone, string secondaryTelephone){
            this.ContactInformation.ContactName = contactName;
            this.ContactInformation.PrimaryTelephone = primaryTelephone;
            this.ContactInformation.SecondaryTelephone = secondaryTelephone;

            // To Do: send event
        }

        public void Activate(){
            if (!this.Active)
            {
                this.Active = true;
                //DomainEventPublisher.Instance.Publish(new TenantActivated(this.TenantId));
            }
        }

        public void Deactivate() { 
            if (this.Active)
            {
                this.Active = false;

                //DomainEventPublisher.Instance.Publish(new TenantDeactivated(this.TenantId));
            }
        }

        #endregion
    }
}
