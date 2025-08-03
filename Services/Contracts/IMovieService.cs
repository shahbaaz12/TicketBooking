using TicketBooking.Models;

namespace TicketBooking.Services.Contracts
{
    public interface IMovieService
    {
        Task AddMovieAsync(Movie request);
        Task<List<Movie>> GetAllMoviesAsync();
     }
}