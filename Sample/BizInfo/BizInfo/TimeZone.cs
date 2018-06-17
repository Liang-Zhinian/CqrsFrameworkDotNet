using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SaaSEqt.BizInfo
{
    public class TimeZone
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }

    }
}
