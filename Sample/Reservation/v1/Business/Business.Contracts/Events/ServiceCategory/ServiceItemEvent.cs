using System;
namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceItemEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public int IndustryStandardCategoryId { get; set; }
        public Guid SiteId { get; set; }
        public int DefaultTimeLength { get; set; }
    }
}
