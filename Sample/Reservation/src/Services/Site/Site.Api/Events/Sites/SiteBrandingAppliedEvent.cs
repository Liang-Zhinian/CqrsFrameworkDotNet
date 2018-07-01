using System;
using CqrsFramework.Events;

namespace SaaSEqt.eShop.Site.Api.Events.Sites
{
    public class SiteBrandingAppliedEvent : IEvent
    {
        public SiteBrandingAppliedEvent()
        {
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
