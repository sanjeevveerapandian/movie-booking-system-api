using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Booking;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(
        IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateBookingDto request)
    {
        var userId =
            long.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

        var result =
            await _bookingService
                .CreateAsync(
                    userId,
                    request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>
    Get(long id)
    {
        var result =
            await _bookingService
                .GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [Authorize(Roles = "User")]
    [HttpGet("my-bookings")]
    public async Task<IActionResult>
    GetMyBookings()
    {
        var userId =
            long.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

        return Ok(
            await _bookingService
                .GetMyBookingsAsync(
                    userId));
    }
}