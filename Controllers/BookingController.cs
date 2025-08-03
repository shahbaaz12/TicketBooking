using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Models.Dtos.Show;
using TicketBooking.Services.Contracts;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController :  ControllerBase 
    {
        private readonly IShowService _showService;
        public BookingController(IShowService ss)
        {
            _showService = ss;
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] BookingReqest showReqest)
        {
            await _showService.BookAShow(showReqest.showId, showReqest.seatId);
            return Ok(new { message = "Booking successful" });
        }
    }
}
