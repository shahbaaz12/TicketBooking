namespace TicketBooking.Models
{
    public class Region : BaseModel
    {
        public string Name { get; set; }
        public List<Theater>? Theaters { get; set; }

    }
}
