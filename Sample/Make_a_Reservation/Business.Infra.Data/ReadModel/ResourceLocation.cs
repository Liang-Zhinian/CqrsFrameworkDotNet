using System;
using Business.Infra.Data.ReadModel.Security;
using System.ComponentModel.DataAnnotations;

namespace Business.Infra.Data.ReadModel
{
    public class ResourceLocation
    {
        [Key]
        public string Id { get; set; }

        public string ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public string LocationId { get; set; }
        public virtual Location Location { get; set; }

    }
}
