using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Infra.Data.ReadModel
{
    public class ResourceStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
