using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeatsController : ControllerBase
{
    private readonly ISeatService _seatService;

    public SeatsController(
        ISeatService seatService)
    {
        _seatService = seatService;
    }

    [HttpGet("availability")]
    public async Task<IActionResult> GetAvailability(
        long showId,
        long screenId)
    {
        return Ok(
            await _seatService
                .GetAvailableSeatsAsync(
                    showId,
                    screenId));
    }
}