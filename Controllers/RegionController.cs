using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketBooking.Constants;
using TicketBooking.Helpers;
using TicketBooking.Models;
using TicketBooking.Models.Dtos;
using TicketBooking.Models.Dtos.Regions;
using TicketBooking.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        // GET: api/<RegionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var model = await _regionService.GetAllRegionsAsync();
            var response = ApiResponseHelper.BuildResponse(model);
            return Ok(response);
        }

        // GET api/<RegionsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _regionService.GetRegionByIdAsync(id);
            var response = ApiResponseHelper.BuildResponse(model);
            return Ok(response);
        }

        // POST api/<RegionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionRequest region)
        {
             await _regionService.AddRegionAsync(region);
             return Created();
        }

        // PUT api/<RegionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RegionRequest region)
        {
            if (region == null || region.Id != id)
            {
                var response = ApiResponseHelper.BuildResponse<Region>(null,REQEUST_RESPONSE.BAD_REQUEST);

                return BadRequest(response);
            }
            await _regionService.UpdateRegionAsync(region);
            return NoContent();

        }

        // DELETE api/<RegionsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _regionService.RemoveRegionAsync(id);
        }
    }
}
