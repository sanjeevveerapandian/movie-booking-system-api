namespace MovieBooking.Application.DTOs.Ticket;

public class TicketResponseDto
{
    public string FilePath { get; set; }
        = string.Empty;

    public string InvoiceNumber { get; set; }
        = string.Empty;

    public string DownloadUrl { get; set; }
        = string.Empty;
}