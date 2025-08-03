using TicketBooking.Models;
 
namespace TicketBooking.Repositories.Contracts
{
    public interface IMovieRepository
    {
        Task AddMovieAsync(Movie Movie);
        Task<List<Movie>> GetAllMoviesAsync();
       
    }
}
