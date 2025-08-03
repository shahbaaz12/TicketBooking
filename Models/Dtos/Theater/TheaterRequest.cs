using System.Text.Json.Serialization;

namespace TicketBooking.Models.Dtos.Theater
{
    public class TheaterRequest
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Screen> Screens { get; set; }
        public int RegionId { get;   set; }
    }
}
