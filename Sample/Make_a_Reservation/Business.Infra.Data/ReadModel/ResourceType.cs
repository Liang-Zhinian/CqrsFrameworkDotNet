using System;
namespace Business.Infra.Data.ReadModel
{
    public class ResourceType: BaseObject<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
