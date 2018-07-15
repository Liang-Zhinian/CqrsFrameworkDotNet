using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain
{
    public class TimeZone
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }
    }
}
