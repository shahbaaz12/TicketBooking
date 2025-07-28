using TicketBooking.Models;
using TicketBooking.Models.Dtos.Regions;
using TicketBooking.Repositories.Contracts;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Services
{


    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task AddRegionAsync(RegionRequest request)
        {
            if (request == null)
            {
                
                throw new ArgumentNullException(nameof(request), "Region cannot be null");
            }
            var region = new Region
            {
                Name = request.Name,
            };
            await _regionRepository.AddRegionAsync(region);
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _regionRepository.GetAllRegionsAsync();
        }

        public async Task<Region?> GetRegionAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _regionRepository.GetRegionByIdAsync(id);
        }

        public async Task<Region?> GetRegionByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _regionRepository.GetRegionByIdAsync(id);
        }

        public async Task RemoveRegionAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var region = await _regionRepository.GetRegionByIdAsync(id);
            if (region == null)
            {
                throw new KeyNotFoundException($"Region with ID {id} not found.");
            }

            await _regionRepository.RemoveRegionAsync(id);
        }


        public async Task UpdateRegionAsync(RegionRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Region cannot be null");
            }

            var existingRegion = await _regionRepository.GetRegionByIdAsync(request.Id.Value);
            if (existingRegion == null)
            {
                throw new KeyNotFoundException($"Region with ID {request.Id} not found.");
            }
            var region = new Region
            {
                Id = request.Id.Value,
                Name = request.Name ,
            };
            await _regionRepository.UpdateRegionAsync(region);
        }
    }
}
