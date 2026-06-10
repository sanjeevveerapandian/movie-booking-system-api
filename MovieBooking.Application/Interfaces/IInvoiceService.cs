using MovieBooking.Application.DTOs.Invoice;

namespace MovieBooking.Application.Interfaces;

public interface IInvoiceService
{
    Task<InvoiceResponseDto> CreateAsync(
        CreateInvoiceDto request);
}