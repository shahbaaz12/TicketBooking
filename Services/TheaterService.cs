using TicketBooking.Models;
using TicketBooking.Models.Dtos.Theater;
 using TicketBooking.Repositories.Contracts;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Services
{


    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _TheaterRepository;

        public TheaterService(ITheaterRepository TheaterRepository)
        {
            _TheaterRepository = TheaterRepository;
        }

        public async Task AddTheaterAsync(TheaterRequest request)
        {
            if (request == null)
            {
                
                throw new ArgumentNullException(nameof(request), "Theater cannot be null");
            }
            var Theater = new Theater
            {
                Name = request.Name,
                Address = request.Address,
                Screens = request.Screens,
                RegionId = request.RegionId
            };
            await _TheaterRepository.AddTheaterAsync(Theater);
        }

        public async Task<List<Theater>> GetAllTheatersAsync()
        {
            return await _TheaterRepository.GetAllTheatersAsync();
        }

        public async Task<Theater?> GetTheaterAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _TheaterRepository.GetTheaterByIdAsync(id);
        }

        public async Task<Theater?> GetTheaterByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _TheaterRepository.GetTheaterByIdAsync(id);
        }

        public async Task RemoveTheaterAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var Theater = await _TheaterRepository.GetTheaterByIdAsync(id);
            if (Theater == null)
            {
                throw new KeyNotFoundException($"Theater with ID {id} not found.");
            }

            await _TheaterRepository.RemoveTheaterAsync(id);
        }


        public async Task UpdateTheaterAsync(TheaterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Theater cannot be null");
            }

            var existingTheater = await _TheaterRepository.GetTheaterByIdAsync(request.Id.Value);
            if (existingTheater == null)
            {
                throw new KeyNotFoundException($"Theater with ID {request.Id} not found.");
            }
            var Theater = new Theater
            {
                Id = request.Id.Value,
                Name = request.Name ,
            };
            await _TheaterRepository.UpdateTheaterAsync(Theater);
        }
    }
}
