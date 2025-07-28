using TicketBooking.Models;
using TicketBooking.Models.Dtos.Regions;

namespace TicketBooking.Services.Contracts
{
    public interface IRegionService
    {
        Task AddRegionAsync(RegionRequest region);
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionAsync(int id);
        Task<Region?> GetRegionByIdAsync(int id);
        Task RemoveRegionAsync(int id);
        Task UpdateRegionAsync(RegionRequest region);
    }
}
