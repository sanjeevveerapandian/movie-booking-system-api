using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Admin;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(
        IAdminService adminService)
    {
        _adminService = adminService;
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpPost("create-theater-admin")]
    public async Task<IActionResult>
        CreateTheaterAdmin(
            CreateTheaterAdminDto dto)
    {
        await _adminService
            .CreateTheaterAdminAsync(dto);

        return Ok(new
        {
            Message =
                "Theater Admin Created Successfully"
        });
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        return Ok(new
        {
            Message = "Welcome Super Admin"
        });
    }
}