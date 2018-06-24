using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Entities
{
    public class ResourceStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
