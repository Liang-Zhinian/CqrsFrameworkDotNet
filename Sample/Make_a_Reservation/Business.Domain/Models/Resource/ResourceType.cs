using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Models
{
    public class ResourceType
    {
        public int Id {get; set;}
        public string Label {get; set;}

        private ResourceType()
        {

        }
    }
}
