using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Application.DTOs.Invoice;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoicesController(
        IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateInvoiceDto request)
    {
        return Ok(
            await _invoiceService.CreateAsync(
                request));
    }
}