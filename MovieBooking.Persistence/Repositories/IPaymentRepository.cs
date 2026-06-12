using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IPaymentRepository
{
    Task<Payment> CreateAsync(
        Payment payment);

    Task<Payment?> GetByIdAsync(
        long paymentId);
}