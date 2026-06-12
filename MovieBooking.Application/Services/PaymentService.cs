using MovieBooking.Application.DTOs.Invoice;
using MovieBooking.Application.DTOs.Payment;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IInvoiceService _invoiceService;
    private readonly ITicketService _ticketService;
    private readonly IEmailService _emailService;
    private readonly IBookingRepository _bookingRepository;

    public PaymentService(
        IPaymentRepository paymentRepository,
        IInvoiceService invoiceService,
        ITicketService ticketService,
        IEmailService emailService,
        IBookingRepository bookingRepository)
    {
        _paymentRepository = paymentRepository;
        _invoiceService = invoiceService;
        _ticketService = ticketService;
        _emailService = emailService;
        _bookingRepository = bookingRepository;
    }

    public async Task<PaymentResponseDto> CreateAsync(
        CreatePaymentDto request)
    {
        var payment = new Payment
        {
            BookingId = request.BookingId,
            Amount = 0,
            TransactionId = Guid.NewGuid().ToString(),
            PaymentStatus = "Success",
            PaidAt = DateTime.UtcNow
        };

        await _paymentRepository.CreateAsync(
            payment);

        var invoice =
            await _invoiceService.CreateAsync(
                new CreateInvoiceDto
                {
                    BookingId = request.BookingId
                });

        var ticket =
            await _ticketService.GenerateAsync(
                request.BookingId);

        var booking =
            await _bookingRepository.GetByIdAsync(
                request.BookingId);

        if (booking != null)
        {
            await _emailService.SendAsync(
                booking.User.Email,
                "Movie Ticket Confirmation",
                $@"
                <h2>Movie Booking Confirmed</h2>
                <p>Invoice Number: {invoice.InvoiceNumber}</p>
                <p>Movie: {booking.Show.Movie.Title}</p>
                <p>Theater: {booking.Show.Screen.Theater.Name}</p>
                <p>Thank you for booking with us.</p>
                ",
                ticket.FilePath);
        }

        return new PaymentResponseDto
        {
            PaymentId = payment.Id,
            Status = payment.PaymentStatus!,
            TransactionId = payment.TransactionId!
        };
    }
}