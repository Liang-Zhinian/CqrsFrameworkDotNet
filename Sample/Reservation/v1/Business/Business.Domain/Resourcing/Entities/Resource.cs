using System;
using System.Collections.Generic;
using Business.Domain.Identity.Entities;

namespace Business.Domain.Resourcing.Entities
{
    public class Resource
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public int ResourceStatusId { get; private set; }
        public virtual ResourceStatus ResourceStatus { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; set; }
    }
}
