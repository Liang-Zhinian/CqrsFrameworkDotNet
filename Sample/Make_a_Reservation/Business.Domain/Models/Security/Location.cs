﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Locations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models.Security
{
    public class Location : BaseObject
    {

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public virtual LocationContact Contact { get; set; }

        [NotMapped]
        public virtual LocationAddress Address { get; set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }
    }
}
