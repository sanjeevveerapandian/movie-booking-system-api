using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("{bookingId}")]
    public async Task<IActionResult> Generate(
        long bookingId)
    {
        var result =
            await _ticketService.GenerateAsync(
                bookingId);

        return Ok(result);
    }
}