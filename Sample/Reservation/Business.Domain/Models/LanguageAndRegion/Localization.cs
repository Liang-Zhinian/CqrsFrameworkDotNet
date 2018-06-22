using System;
using System.Collections.Generic;

namespace Business.Domain.Models.Localization
{
    public class Culture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<LocalicationResource> Resources { get; set; }
    }

    public class LocalicationResource
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
