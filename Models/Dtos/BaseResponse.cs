using TicketBooking.Constants;

namespace TicketBooking.Models.Dtos
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }   
        public string? Message { get; set; }
        public string? Error { get; set; }
    }

}
