using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicService.ReservationService.WriteModel.Domain
{
    public class ReservationType : AggregateRoot
    {
        private readonly string _name;
    }
}
