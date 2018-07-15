using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Resourcing.Entities
{
    public class ResourceStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
