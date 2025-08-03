using System.Text.Json.Serialization;

namespace TicketBooking.Models.Dtos.Show
{
    public class ShowRequest
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }
        public DateTime StartDate { get; set; } 

        public int MovieId { get; set; }
         public int ScreenId { get; set; }
     
    }
}
