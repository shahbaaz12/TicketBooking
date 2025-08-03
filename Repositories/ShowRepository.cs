using Microsoft.EntityFrameworkCore;
using System.Data;
using TicketBooking.Constants;
using TicketBooking.Models;
using TicketBooking.Models.EntityContext;
using TicketBooking.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace TicketBooking.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly TicketBookingContext _context;

        public ShowRepository(TicketBookingContext context)
        {
            _context = context;
        }

        public async Task AddShowAsync(Show Show)
        {
            if (Show == null)
            {
                throw new ArgumentNullException(nameof(Show), "Show cannot be null");
            }
            await _context.Shows.AddAsync(Show);
            await _context.SaveChangesAsync();
        }

        public async Task BookAShow(int showId, int seatId)
        {
            var show = _context.Shows.Where(x => x.Id == seatId).FirstOrDefault();
            using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

            var seat = _context.ShowSeats.Where(x => x.Id == seatId).FirstOrDefault();

            if (seat.Status != SEAT_STATUS.OCCUPIED)
                throw new Exception("Already Booked");
            seat.Status = SEAT_STATUS.RESERVED;

            _context.SaveChanges();
            await transaction.CommitAsync();

        }


        public async Task<List<Show>> GetAllShowsAsync()
        {
            return await _context.Shows 
                .Include(r => r.Movie)
                .Include(s => s.ShowSeats).ThenInclude(x => x.Seat).ThenInclude(x => x.SeatType)
                .Include(s => s.ShowSeatTypes).ToListAsync();
        }

        public async Task<Show?> GetShowByIdAsync(int id)
        {
            return await _context.Shows
                .Include(r => r.ShowSeats)
                .Include(r => r.Screen)
                .ThenInclude(s => s.Seats)
                .ThenInclude(s => s.SeatType)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task RemoveShowAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var Show = await _context.Shows.FindAsync(id);
            if (Show == null)
            {
                throw new KeyNotFoundException($"Show with ID {id} not found.");
            }

            _context.Shows.Remove(Show);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShowAsync(Show Show)
        {
            _context.Entry(Show).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

    }
}
