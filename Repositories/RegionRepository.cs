using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;
using TicketBooking.Models.EntityContext;
using TicketBooking.Repositories.Contracts;

namespace TicketBooking.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly TicketBookingContext _context;

        public RegionRepository(TicketBookingContext context)
        {
            _context = context;
        }

        public async Task AddRegionAsync(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region), "Region cannot be null");
            }
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(int id)
        {
            return await _context.Regions
                .Include(r => r.Theaters)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task RemoveRegionAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var region = await _context.Regions.FindAsync(id);
            if (region == null)
            {
                throw new KeyNotFoundException($"Region with ID {id} not found.");
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRegionAsync(Region region)
        {
            if (region == null)
                throw new ArgumentNullException(nameof(region), "Region cannot be null");

            var existingRegion = await _context.Regions.FindAsync(region.Id);
            if (existingRegion == null)
                throw new KeyNotFoundException($"Region with ID {region.Id} not found.");

            // Update only the intended fields
            existingRegion.Name = region.Name;
            // Add other field updates as needed

            await _context.SaveChangesAsync();
        }

    }
}
