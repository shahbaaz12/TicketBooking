using TicketBooking.Constants;

namespace TicketBooking.Models
{
    public class Screen : BaseModel
    {
        public string Name { get; set; }

        public int TheatreId { get; set; }
        public Theater? Theater { get; set; }
        public List<Seat>? Seats { get; set; }
        public List<FEATURES>? Features { get; set; }
    }
}
