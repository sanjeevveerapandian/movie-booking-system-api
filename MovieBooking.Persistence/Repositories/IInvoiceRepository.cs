using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IInvoiceRepository
{
    Task<Invoice> CreateAsync(
        Invoice invoice);

    Task<Invoice?> GetByBookingIdAsync(
        long bookingId);

    Task UpdateAsync(
        Invoice invoice);
}