using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await _movieService.AddMovieAsync(movie);
            return NoContent();

        }
    }
}
