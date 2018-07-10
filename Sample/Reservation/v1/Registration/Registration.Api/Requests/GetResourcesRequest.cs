using System;
using System.Collections.Generic;

namespace Registration.Api.Requests
{
    public class GetResourcesRequest:BaseRequest
    {
        public GetResourcesRequest()
        {
        }

        public ICollection<Guid> SessionTypeIDs { get; set; }
        public Guid LocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
