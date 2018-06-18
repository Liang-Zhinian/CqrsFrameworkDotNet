using System;
namespace Business.Domain.Events.ServiceCategory
{
    public class ServiceEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TenantId { get; set; }
    }
}
