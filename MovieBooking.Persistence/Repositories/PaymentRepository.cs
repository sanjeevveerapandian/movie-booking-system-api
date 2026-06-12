using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly MovieBookingDbContext _context;

    public PaymentRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> CreateAsync(
        Payment payment)
    {
        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task<Payment?> GetByIdAsync(
        long paymentId)
    {
        return await _context.Payments

            .Include(x => x.Booking)
                .ThenInclude(x => x.User)

            .FirstOrDefaultAsync(
                x => x.Id == paymentId);
    }
}