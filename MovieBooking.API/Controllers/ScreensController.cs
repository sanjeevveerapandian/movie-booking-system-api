using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Screen;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreensController : ControllerBase
{
    private readonly IScreenService _screenService;

    public ScreensController(
        IScreenService screenService)
    {
        _screenService = screenService;
    }

    [Authorize(Roles = "TheaterAdmin")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateScreenDto request)
    {
        return Ok(
            await _screenService.CreateAsync(request));
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _screenService.GetAllAsync());
    }
}