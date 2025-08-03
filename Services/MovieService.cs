using TicketBooking.Models;
using TicketBooking.Repositories.Contracts;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Services
{


    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _MovieRepository;

        public MovieService(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;
        }

        public async Task AddMovieAsync(Movie movie)
        {

            await _MovieRepository.AddMovieAsync(movie);
        }



        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _MovieRepository.GetAllMoviesAsync();
        }


    }
}
