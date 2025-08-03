using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;
using TicketBooking.Models.EntityContext;
using TicketBooking.Repositories.Contracts;

namespace TicketBooking.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly TicketBookingContext _context;

        public TheaterRepository(TicketBookingContext context)
        {
            _context = context;
        }

        public async Task AddTheaterAsync(Theater Theater)
        {
            if (Theater == null)
            {
                throw new ArgumentNullException(nameof(Theater), "Theater cannot be null");
            }
            await _context.Theaters.AddAsync(Theater);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Theater>> GetAllTheatersAsync()
        {
            return await _context.Theaters.Include(x => x.Screens ).ThenInclude(x => x.Seats).ThenInclude(x => x.SeatType).ToListAsync();
        }

        public async Task<Theater?> GetTheaterByIdAsync(int id)
        {
            return await _context.Theaters
                .Include(r => r.Screens)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task RemoveTheaterAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var Theater = await _context.Theaters.FindAsync(id);
            if (Theater == null)
            {
                throw new KeyNotFoundException($"Theater with ID {id} not found.");
            }

            _context.Theaters.Remove(Theater);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTheaterAsync(Theater Theater)
        {
            if (Theater == null)
                throw new ArgumentNullException(nameof(Theater), "Theater cannot be null");

            var existingTheater = await _context.Theaters.FindAsync(Theater.Id);
            if (existingTheater == null)
                throw new KeyNotFoundException($"Theater with ID {Theater.Id} not found.");

            // Update only the intended fields
            existingTheater.Name = Theater.Name;
            // Add other field updates as needed

            await _context.SaveChangesAsync();
        }

    }
}
