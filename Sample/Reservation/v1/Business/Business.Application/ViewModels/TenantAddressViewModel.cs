using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Application.ViewModels
{
    public class TenantAddressViewModel
    {
        public TenantAddressViewModel()
        {
        }

        public TenantAddressViewModel(Guid id,
                                      Guid tenantId,
                                      string address,
                                      string address2,
                               string city, 
                                      string state,
                                      string postalCode,
                               string country )
        {
            Id = id;
            TenantId = tenantId;
            StateProvince = state;
            City = city;
            StreetAddress = address;
            StreetAddress2 = address2;
            CountryCode = country;
            PostalCode = postalCode;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Street is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address")]
        public string StreetAddress { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address (line 2)")]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "The City is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "The State is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("State")]
        public string StateProvince { get; set; }

        [Required(ErrorMessage = "The Country is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Country")]
        public string CountryCode { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("PostalCode")]
        public string PostalCode { get; set; }

        public Guid TenantId { get; set; }

        //[Required(ErrorMessage = "The BirthDate is Required")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayName("Birth Date")]
        //public DateTime BirthDate { get; set; }

    }
}
