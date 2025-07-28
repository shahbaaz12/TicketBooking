namespace TicketBooking.Models
{
    public class Show : BaseModel
    {
        public DateTime StartDate { get; set; }
        public Movie movie { get; set; }
        public Screen screen { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
        public List<ShowSeatType> ShowSeatTypes { get; set; }

    }
}