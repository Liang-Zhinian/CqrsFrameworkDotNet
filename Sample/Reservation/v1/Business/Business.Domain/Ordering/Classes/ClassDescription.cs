using System;
using Business.Domain.Catalog.SchedulableCatalog.Entities;

namespace Business.Domain.Entities.Orders
{
    public class ClassDescription
    {
        public ClassDescription()
        {
        }

        public Guid Id { get; private set; }

        public byte[] Image { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Prereq { get; private set; }

        public string Notes { get; private set; }

        public DateTime LastUpdated { get; private set; }

        //public Program Program { get; private set; }

        public SchedulableCatalogItem SchedulableCatalogItem { get; private set; }

        public bool Active { get; private set; }
    }
}
