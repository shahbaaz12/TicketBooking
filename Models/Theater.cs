namespace TicketBooking.Models
{
    public class Theater : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        
        public int RegionId { get; set; }
        public Region? Region { get; set; }
        public List<Screen>? Screens { get; set; }


    }
}
