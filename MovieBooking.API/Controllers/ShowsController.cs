using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Show;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowsController : ControllerBase
{
    private readonly IShowService _showService;

    public ShowsController(
        IShowService showService)
    {
        _showService = showService;
    }

    [Authorize(Roles = "TheaterAdmin")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateShowDto request)
    {
        return Ok(
            await _showService.CreateAsync(request));
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _showService.GetAllAsync());
    }
}