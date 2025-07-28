using TicketBooking.Constants;

namespace TicketBooking.Models
{
    public class Booking : BaseModel
    {

        public User BookedBy { get; set; }

        public DateTime Date { get; set; }
        public int  Amount { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
        public List<Payment> Payments { get; set; }
        public BOOKING_STATUS BookingStatus { get; set; }
    }
}
