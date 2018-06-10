﻿using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class StaffContact
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        public StaffContact()
        {
        }
    }
}
