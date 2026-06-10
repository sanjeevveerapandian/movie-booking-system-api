namespace MovieBooking.Application.DTOs.Payment;

public class PaymentResponseDto
{
    public long PaymentId { get; set; }

    public string Status { get; set; } = string.Empty;

    public string TransactionId { get; set; } = string.Empty;
}