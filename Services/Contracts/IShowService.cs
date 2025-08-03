using TicketBooking.Models;
using TicketBooking.Models.Dtos.Show;
 
namespace TicketBooking.Services.Contracts
{
    public interface IShowService
    {
        Task AddShowAsync(ShowRequest Show);
        Task<List<Show>> GetAllShowsAsync();
        Task<Show?> GetShowAsync(int id);
        Task<Show?> GetShowByIdAsync(int id);
        Task RemoveShowAsync(int id);
        Task UpdateShowAsync(ShowRequest Show);
        Task BookAShow(int showId, int seatId);
    }
}
