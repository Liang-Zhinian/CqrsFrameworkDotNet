using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
//using Business.Domain.Models.Service.PaymentOption;

namespace Business.Domain.Models.Service
{
    public class ServiceCategory<TService> : AggregateRoot 
        where TService : class
    {
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
