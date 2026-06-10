using MovieBooking.Application.DTOs.Payment;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(
        IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentResponseDto> CreateAsync(
        CreatePaymentDto request)
    {
        var payment = new Payment
        {
            BookingId = request.BookingId,
            Amount = 0,
            TransactionId =
                Guid.NewGuid().ToString(),
            PaymentStatus = "Success",
            PaidAt = DateTime.UtcNow
        };

        await _paymentRepository.CreateAsync(
            payment);

        return new PaymentResponseDto
        {
            PaymentId = payment.Id,
            Status = payment.PaymentStatus!,
            TransactionId =
                payment.TransactionId!
        };
    }
}