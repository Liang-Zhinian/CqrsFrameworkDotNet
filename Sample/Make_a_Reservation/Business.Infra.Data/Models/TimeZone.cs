using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models
{
    public class TimeZone
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }

        public TimeZone()
        {
        }
    }
}
