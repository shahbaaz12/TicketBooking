using TicketBooking.Models;
using TicketBooking.Models.Dtos.Regions;

namespace TicketBooking.Repositories.Contracts
{
    public interface IRegionRepository
    {
        Task AddRegionAsync(Region region);
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(int id);
        Task RemoveRegionAsync(int id);
        Task UpdateRegionAsync(Region region);
    }
}
