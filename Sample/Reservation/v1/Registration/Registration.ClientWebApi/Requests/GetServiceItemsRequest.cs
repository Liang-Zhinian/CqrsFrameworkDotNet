using System;
namespace Registration.ClientWebApi.Requests
{
    public class GetServiceItemsRequest : BaseRequest
    {
        public GetServiceItemsRequest()
        {
        }

        public Registration.Domain.ReadModel.Program[] ProgramIds { get; set; }
        public bool OnlineOnly { get; set; }
    }
}
