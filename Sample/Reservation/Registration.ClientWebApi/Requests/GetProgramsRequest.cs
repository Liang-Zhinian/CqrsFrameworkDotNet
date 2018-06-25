using System;
namespace Registration.ClientWebApi.Requests
{
    public class GetProgramsRequest:BaseRequest
    {
        public GetProgramsRequest()
        {
        }

        public string /* or class ScheduleType */ ScheduleType { get; set; }
        public bool OnlineOnly { get; set; }
    }
}
