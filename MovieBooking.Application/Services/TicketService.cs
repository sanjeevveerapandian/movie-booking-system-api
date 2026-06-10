using MovieBooking.Application.DTOs.Ticket;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class TicketService : ITicketService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IInvoiceRepository _invoiceRepository;

    public TicketService(
        IBookingRepository bookingRepository,
        IInvoiceRepository invoiceRepository)
    {
        _bookingRepository = bookingRepository;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<TicketResponseDto> GenerateAsync(
        long bookingId)
    {
        var booking =
            await _bookingRepository.GetByIdAsync(
                bookingId);

        if (booking == null)
            throw new Exception("Booking not found");

        var invoice =
            await _invoiceRepository
                .GetByBookingIdAsync(bookingId);

        if (invoice == null)
            throw new Exception("Invoice not found");

        return new TicketResponseDto
        {
            FilePath = "TEMP",
            InvoiceNumber =
                invoice.InvoiceNumber ?? "",
            DownloadUrl = "TEMP"
        };
    }
}