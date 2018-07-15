using System;

namespace Business.Domain.Catalog
{
    public abstract class CatalogType
    {
        public Guid Id { get; protected set; }

        public string Type { get; protected set; }
    }
}
