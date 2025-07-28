using System.Text.Json.Serialization;

namespace TicketBooking.Models.Dtos.Regions
{
    public class RegionRequest
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Name")]
        public required string  Name { get; set; }

    }
}
