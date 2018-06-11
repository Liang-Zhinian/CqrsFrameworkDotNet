using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Infra.Data.ReadModel
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
