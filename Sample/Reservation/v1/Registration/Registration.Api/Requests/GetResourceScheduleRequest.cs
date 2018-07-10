using System;
namespace Registration.Api.Requests
{
    public class GetResourceScheduleRequest: BaseRequest
    {
        public GetResourceScheduleRequest()
        {
        }

        public DateTime Date { get; set; }
    }
}
