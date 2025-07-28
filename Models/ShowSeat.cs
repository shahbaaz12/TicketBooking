using TicketBooking.Constants;

namespace TicketBooking.Models
{
    public class ShowSeat : BaseModel
    {
        public Show Show { get; set; }
        public Seat Seat { get; set; }
        public SEAT_STATUS Status { get; set; }
    }
}
