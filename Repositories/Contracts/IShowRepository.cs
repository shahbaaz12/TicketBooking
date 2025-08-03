using TicketBooking.Models;
 
namespace TicketBooking.Repositories.Contracts
{
    public interface IShowRepository
    {
        Task AddShowAsync(Show Show);
        Task BookAShow(int showId, int seatId);
        Task<List<Show>> GetAllShowsAsync();
        Task<Show?> GetShowByIdAsync(int id);
        Task RemoveShowAsync(int id);
        Task UpdateShowAsync(Show Show);
    }
}
