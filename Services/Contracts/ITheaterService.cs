using TicketBooking.Models;
using TicketBooking.Models.Dtos.Theater;
 
namespace TicketBooking.Services.Contracts
{
    public interface ITheaterService
    {
        Task AddTheaterAsync(TheaterRequest Theater);
        Task<List<Theater>> GetAllTheatersAsync();
        Task<Theater?> GetTheaterAsync(int id);
        Task<Theater?> GetTheaterByIdAsync(int id);
        Task RemoveTheaterAsync(int id);
        Task UpdateTheaterAsync(TheaterRequest Theater);
    }
}
