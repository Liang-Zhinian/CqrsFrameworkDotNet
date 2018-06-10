using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string RegionString { get; set; }
        public string Abbreviation { get; set; }
        public string EquivalentLocaleName { get; set; }

        public Region()
        {
        }
    }
}
