using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;
using TicketBooking.Models.EntityContext;
using TicketBooking.Repositories.Contracts;

namespace TicketBooking.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly TicketBookingContext _context;

        public MovieRepository(TicketBookingContext context)
        {
            _context = context;
        }

        public async Task AddMovieAsync(Movie Movie)
        {
            if (Movie == null)
            {
                throw new ArgumentNullException(nameof(Movie), "Movie cannot be null");
            }
            await _context.Movies.AddAsync(Movie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        



    }
}
