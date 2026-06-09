using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Theater;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TheatersController : ControllerBase
{
    private readonly ITheaterService _theaterService;

    public TheatersController(
        ITheaterService theaterService)
    {
        _theaterService = theaterService;
    }

    [Authorize(Roles = "TheaterAdmin")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTheaterDto request)
    {
        var ownerId =
            long.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

        var result =
            await _theaterService.CreateAsync(
                ownerId,
                request);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _theaterService.GetAllAsync());
    }
}