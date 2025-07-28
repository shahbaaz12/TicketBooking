namespace TicketBooking.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Booking> Booking { get; set; }
    }
}
