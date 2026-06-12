using MovieBooking.Application.DTOs.Ticket;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Repositories;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

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

        var fileName =
            $"ticket_{bookingId}.pdf";

        var ticketsFolder =
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "tickets");

        if (!Directory.Exists(ticketsFolder))
        {
            Directory.CreateDirectory(
                ticketsFolder);
        }

        var filePath =
            Path.Combine(
                ticketsFolder,
                fileName);

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header()
                    .Text("Movie Ticket")
                    .FontSize(24)
                    .Bold();

                page.Content()
                    .Column(column =>
                    {
                        column.Item().Text(
                            $"Invoice Number: {invoice.InvoiceNumber}");

                        column.Item().Text(
                            $"Movie: {booking.Show.Movie.Title}");

                        column.Item().Text(
                            $"Theater: {booking.Show.Screen.Theater.Name}");

                        column.Item().Text(
                            $"Screen: {booking.Show.Screen.Name}");

                        column.Item().Text(
                            $"Show Time: {booking.Show.StartTime}");

                        column.Item().Text(
                            $"Customer: {booking.User.Email}");

                        column.Item().Text(
                            $"Amount: ₹{booking.TotalAmount}");

                        column.Item().Text(
                            $"Seats: {string.Join(", ",
                                booking.BookingSeats
                                    .Select(x => x.Seat.SeatNumber))}");
                    });

                page.Footer()
                    .AlignCenter()
                    .Text("MovieBooking System");
            });
        })
        .GeneratePdf(filePath);

        invoice.PdfUrl =
            $"/tickets/{fileName}";

        await _invoiceRepository
            .UpdateAsync(invoice);

        return new TicketResponseDto
        {
            FilePath = filePath,
            InvoiceNumber =
                invoice.InvoiceNumber ?? string.Empty,

            DownloadUrl =
                invoice.PdfUrl
        };
    }
}