using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly MovieBookingDbContext _context;

    public InvoiceRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice> CreateAsync(
        Invoice invoice)
    {
        _context.Invoices.Add(invoice);

        await _context.SaveChangesAsync();

        return invoice;
    }

    public async Task<Invoice?> GetByBookingIdAsync(
        long bookingId)
    {
        return await _context.Invoices
            .FirstOrDefaultAsync(
                x => x.BookingId == bookingId);
    }

    public async Task UpdateAsync(
        Invoice invoice)
    {
        _context.Invoices.Update(invoice);

        await _context.SaveChangesAsync();
    }
}