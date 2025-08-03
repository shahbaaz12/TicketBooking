namespace TicketBooking.Models
{
    public class ShowSeatType : BaseModel
    {
        public int ShowId { get; set; }
        public Show? Show { get; set; }
        public SeatType? SeatType { get; set; }
        public int SeatTypeId { get; set; }

        public int Price { get; set; }
    }
}
