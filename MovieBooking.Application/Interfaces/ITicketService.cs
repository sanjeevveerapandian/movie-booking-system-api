using MovieBooking.Application.DTOs.Ticket;

namespace MovieBooking.Application.Interfaces;

public interface ITicketService
{
    Task<TicketResponseDto> GenerateAsync(
        long bookingId);
}