using System;
using System.Collections.Generic;
using Business.Infra.Data.ReadModel.Service.PaymentOption;

namespace Business.Infra.Data.ReadModel.Service
{
    public class ServiceCategory<TService> where TService : class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TService> Services { get; set; }

        public ServiceCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
