using TicketBooking.Models;
 
namespace TicketBooking.Repositories.Contracts
{
    public interface ITheaterRepository
    {
        Task AddTheaterAsync(Theater Theater);
        Task<List<Theater>> GetAllTheatersAsync();
        Task<Theater?> GetTheaterByIdAsync(int id);
        Task RemoveTheaterAsync(int id);
        Task UpdateTheaterAsync(Theater Theater);
    }
}
