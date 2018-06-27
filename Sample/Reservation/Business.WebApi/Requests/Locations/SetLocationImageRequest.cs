using System;
namespace Business.WebApi.Requests.Locations
{
    public class SetLocationImageRequest
    {
        public Guid Id { get; set; }

        public Guid SiteId { get; set; }

        public byte[] Image { get; set; }
    }
}
