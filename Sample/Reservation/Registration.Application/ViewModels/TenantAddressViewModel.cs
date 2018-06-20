using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Application.ViewModels
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
            State = state;
            City = city;
            Street = address;
            Street2 = address2;
            Country = country;
            PostalCode = postalCode;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Street is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address")]
        public string Street { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address (line 2)")]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "The City is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "The State is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "The Country is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Country")]
        public string Country { get; set; }

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
