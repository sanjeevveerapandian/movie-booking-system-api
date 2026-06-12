namespace MovieBooking.Application.Interfaces;

public interface IEmailService
{
    Task SendAsync(
        string to,
        string subject,
        string body,
        string? attachmentPath = null);
}