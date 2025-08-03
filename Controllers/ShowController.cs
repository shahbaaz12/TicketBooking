using Microsoft.AspNetCore.Mvc;
using TicketBooking.Constants;
using TicketBooking.Helpers;
using TicketBooking.Models;
using TicketBooking.Models.Dtos.Show;
using TicketBooking.Models.Dtos.Show;
using TicketBooking.Services;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController :  ControllerBase  
    {
       private readonly IShowService _showService;

        public ShowController(IShowService showService)
         {
              _showService = showService;
        }

        // GET: api/<ShowController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _showService.GetAllShowsAsync();
            return Ok(model);
        }

        // GET api/<ShowController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _showService.GetShowByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        // POST api/<ShowController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShowRequest request)
        {
            await _showService.AddShowAsync(request);
             return Created();
        }


        // PUT api/<ShowController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ShowRequest request)
        {
            if (request == null || request.Id != id)
            {
                var response = ApiResponseHelper.BuildResponse<Region>(null, REQEUST_RESPONSE.BAD_REQUEST);

                return BadRequest(response);
            }
            await _showService.UpdateShowAsync(request);
            return NoContent();

        }

        // DELETE api/<ShowController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _showService.RemoveShowAsync(id);
        }

    }
}
