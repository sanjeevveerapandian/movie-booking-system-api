using MovieBooking.Application.DTOs.Invoice;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(
        IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<InvoiceResponseDto> CreateAsync(
        CreateInvoiceDto request)
    {
        var invoice = new Invoice
        {
            BookingId = request.BookingId,
            InvoiceDate = DateTime.UtcNow,
            InvoiceNumber =
                $"INV-{DateTime.UtcNow:yyyy}-{Guid.NewGuid().ToString()[..6]}",
            PdfUrl = null
        };

        await _invoiceRepository.CreateAsync(
            invoice);

        return new InvoiceResponseDto
        {
            InvoiceId = invoice.Id,
            InvoiceNumber = invoice.InvoiceNumber!,
            InvoiceDate = invoice.InvoiceDate
        };
    }
}