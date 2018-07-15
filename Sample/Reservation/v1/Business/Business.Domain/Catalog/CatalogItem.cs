using System;

namespace Business.Domain.Catalog
{
    public abstract class CatalogItem
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}