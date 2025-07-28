namespace TicketBooking.Models
{
    public class Seat : BaseModel
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public SeatType SeatType { get; set; }
    }
}
