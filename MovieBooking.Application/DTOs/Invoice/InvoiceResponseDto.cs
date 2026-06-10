namespace MovieBooking.Application.DTOs.Invoice;

public class InvoiceResponseDto
{
    public long InvoiceId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public DateTime InvoiceDate { get; set; }
}