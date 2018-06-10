﻿using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models.Security
{
    public class Branding
    {
        [Key]
        public string Id { get; set; }

        public string LogoURL { get; set; }
        public string PageColor1 { get; set; }
        public string PageColor2 { get; set; }
        public string PageColor3 { get; set; }
        public string PageColor4 { get; set; }

        public string BusinessId { get; set; }
        public Business Business { get; set; }

        public Branding()
        {
        }
    }
}
