using Microsoft.AspNetCore.Mvc;
using TicketBooking.Constants;
using TicketBooking.Helpers;
using TicketBooking.Models;
using TicketBooking.Models.Dtos.Theater;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase 
    {
        private readonly ITheaterService _theaterService;
        public TheaterController(ITheaterService Theaterervice)
        {
            _theaterService = Theaterervice;
        }
        // GET: api/<TheaterController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var model = await _theaterService.GetAllTheatersAsync();
            var response = ApiResponseHelper.BuildResponse(model);
            return Ok(response);
        }

        // GET api/<TheaterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _theaterService.GetTheaterByIdAsync(id);
            var response = ApiResponseHelper.BuildResponse(model);
            return Ok(response);
        }

        // POST api/<TheaterController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TheaterRequest Theater)
        {
            await _theaterService.AddTheaterAsync(Theater);
            return Created();
        }

        // PUT api/<TheaterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TheaterRequest Theater)
        {
            if (Theater == null || Theater.Id != id)
            {
                var response = ApiResponseHelper.BuildResponse<Theater>(null, REQEUST_RESPONSE.BAD_REQUEST);

                return BadRequest(response);
            }
            await _theaterService.UpdateTheaterAsync(Theater);
            return NoContent();

        }

        // DELETE api/<TheaterController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _theaterService.RemoveTheaterAsync(id);
        }

    }
}
