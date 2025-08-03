using TicketBooking.Models;
using TicketBooking.Models.Dtos.Show;
using TicketBooking.Repositories.Contracts;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Services
{


    public class ShowService : IShowService
    {
        private readonly IShowRepository _ShowRepository;

        public ShowService(IShowRepository ShowRepository)
        {
            _ShowRepository = ShowRepository;
        }

        public async Task AddShowAsync(ShowRequest request)
        {
            if (request == null)
            {

                throw new ArgumentNullException(nameof(request), "Show cannot be null");
            }
            var Show = new Show
            {
                StartDate = request.StartDate,
                MovieId = request.MovieId,
                ScreenId = request.ScreenId,
            };
            await _ShowRepository.AddShowAsync(Show);
        }

        public async Task<List<Show>> GetAllShowsAsync()
        {
            return await _ShowRepository.GetAllShowsAsync();
        }

        public async Task<Show?> GetShowAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _ShowRepository.GetShowByIdAsync(id);
        }

        public async Task<Show?> GetShowByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return await _ShowRepository.GetShowByIdAsync(id);
        }

        public async Task RemoveShowAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            var Show = await _ShowRepository.GetShowByIdAsync(id);
            if (Show == null)
            {
                throw new KeyNotFoundException($"Show with ID {id} not found.");
            }

            await _ShowRepository.RemoveShowAsync(id);
        }


        public async Task UpdateShowAsync(ShowRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Show cannot be null");
            }

            var existingShow = await _ShowRepository.GetShowByIdAsync(request.Id.Value);
            if (existingShow == null)
            {
                throw new KeyNotFoundException($"Show with ID {request.Id} not found.");
            }
            var Show = new Show
            {
                Id = request.Id.Value,
                StartDate = request.StartDate,
                MovieId = request.MovieId,
                ScreenId = request.ScreenId
            };
            await _ShowRepository.UpdateShowAsync(Show);
        }

        public async Task BookAShow(int showId, int seatId)
        {
            await _ShowRepository.BookAShow(showId, seatId);
        }
    }
}
