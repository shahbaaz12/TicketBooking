namespace TicketBooking.Models
{
    public class Show : BaseModel
    {
        public DateTime StartDate { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int ScreenId { get; set; }
        public Screen? Screen { get; set; }
        public List<ShowSeat>? ShowSeats { get; set; }
        public List<ShowSeatType>? ShowSeatTypes { get; set; }

    }
}