using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain.Models
{
    public class ResourceStatus
    {
        public int Id {get; set;}
        public string Label {get; set;}

        private ResourceStatus()
        {

        }
    }
}
