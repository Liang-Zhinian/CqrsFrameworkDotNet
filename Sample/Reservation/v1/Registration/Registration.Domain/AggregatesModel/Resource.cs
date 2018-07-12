using System;
namespace Registration.Domain.AggregatesModel
{
    public class Resource
    {
        public Resource()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Guid SiteId { get; set; }
    }
}
