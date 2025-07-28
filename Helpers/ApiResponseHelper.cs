using TicketBooking.Constants;
using TicketBooking.Models.Dtos;

namespace TicketBooking.Helpers
{
    public static class ApiResponseHelper
    {
        public static BaseResponse<T> BuildResponse<T>(T? data, string? notFoundMessage = null)
        {
            bool isEmpty = data == null || (data is IEnumerable<object> collection && !collection.Any());

            return new BaseResponse<T>
            {
                Data = data,
                Message = isEmpty
                    ? notFoundMessage ?? REQEUST_RESPONSE.NOT_FOUND
                    : REQEUST_RESPONSE.SUCCESS,
                Error = null
            };
        }
    }

}
