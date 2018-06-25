using System;
namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
