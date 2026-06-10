using MovieBooking.Application.DTOs.Payment;

namespace MovieBooking.Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponseDto> CreateAsync(
        CreatePaymentDto request);
}