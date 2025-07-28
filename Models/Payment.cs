using TicketBooking.Constants;

namespace TicketBooking.Models
{
    public class Payment : BaseModel
    {
        public DateTime Time { get; set; }
        public int Amount { get; set; }
        public PAYMENT_STATUS status { get; set; }
        public PAYMENT_MODE mode { get; set; }

        public PAYMENT_GATEWAY Gateway { get; set; }
    }
}
