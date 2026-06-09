using Microsoft.AspNetCore.Mvc;
using MovieBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly MovieBookingDbContext _context;

    public TestController(MovieBookingDbContext context)
    {
        _context = context;
    }

    [HttpGet("db")]
    public async Task<IActionResult> CheckDatabase()
    {
        var roles = await _context.Roles.ToListAsync();

        return Ok(new
        {
            Message = "Database Connected Successfully",
            TotalRoles = roles.Count,
            Data = roles
        });
    }
}