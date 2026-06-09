using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(new
        {
            Message = "Authenticated User",

            UserId =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value,

            Email =
                User.FindFirst(ClaimTypes.Email)?.Value,

            Role =
                User.FindFirst(ClaimTypes.Role)?.Value
        });
    }
}