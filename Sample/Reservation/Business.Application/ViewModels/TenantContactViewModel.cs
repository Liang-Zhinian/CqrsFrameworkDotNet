using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Application.ViewModels
{
    public class TenantContactViewModel
    {
        public TenantContactViewModel()
        {
        }

        public TenantContactViewModel(Guid id,
                                      Guid tenantId,
                               string email, 
                               string phone, 
                               string phone2 )
        {
            Id = id;
            Email = email;
            Phone = phone;
            Phone2 = phone2;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("DisplayName")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email2 { get; set; }

        [Required(ErrorMessage = "The MobilePhone is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("MobilePhone")]
        public string Phone { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Phone2")]
        public string Phone2 { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Phone3")]
        public string Phone3 { get; set; }

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

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("ForeignZip")]
        public string ForeignZip { get; set; }

        //[Required(ErrorMessage = "The BirthDate is Required")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayName("Birth Date")]
        //public DateTime BirthDate { get; set; }

    }
}
