using System;
namespace Business.Domain.Models.Services
{
    public class PricingOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GrossPrice { get; set; }
        public int TaxType { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
