using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicService.ReservationService.WriteModel.Domain
{
    public class ResourceType : AggregateRoot
    {
        private readonly string _name;

        private readonly string _description;

        private ResourceType()
        {

        }
    }
}
