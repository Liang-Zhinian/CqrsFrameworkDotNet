using System;
namespace Business.Domain.Entities.ServiceCategories
{
    public class ServiceItem
    {
        private ServiceItem()
        {
            Id = Guid.NewGuid();
        }

        public ServiceItem(Guid siteId, string name, int defaultTimeLength, Guid serviceCategoryId) : this()
        {
            SiteId = siteId;
            Name = name;
            DefaultTimeLength = defaultTimeLength;
            ServiceCategoryId = serviceCategoryId;
            //Action = ActionCode.Added;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Descrtiption { get; private set; }

        public int DefaultTimeLength { get; private set; }

        //public Guid ProgramId { get; private set; }
        //public virtual Program Program { get; private set; }

        //public int NumDeducted { get; private set; }

        //public ActionCode Action { get; private set; }

        public Guid ServiceCategoryId { get; private set; }
        public virtual ServiceCategory ServiceCategory { get; private set; }

        //public double Price { get; private set; }

        //public double TaxRate { get; private set; }

        //public double TaxAmount => Price * TaxRate;

        //public Guid LocationId { get; private set; }
        //public virtual Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }
    }
}
