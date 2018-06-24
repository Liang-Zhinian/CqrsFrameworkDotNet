using System;
namespace Reservation.ClientWebApi.Requests
{
    public class GetResourceScheduleRequest: BaseRequest
    {
        public GetResourceScheduleRequest()
        {
        }

        public DateTime Date { get; set; }
    }
}
