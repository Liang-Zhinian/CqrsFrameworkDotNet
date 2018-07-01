using System;
using CqrsFramework.Domain;

namespace SaaSEqt.eShop.Site.Api.Model
{
    public class ContactInformation
    {
        public ContactInformation()
        {
        }

        public string ContactName { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }
    }
}
