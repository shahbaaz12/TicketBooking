using TicketBooking.Constants;

namespace TicketBooking.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }
        public float Duration { get; set; }
        public int ReleaseYear { get; set; }
        public List<string> Actors { get; set; }
        public List<GENRES> Genres { get; set; }
        public List<LANGUAGES> Languages { get; set; }
        public List<FEATURES> Features { get; set; }
    }
}
