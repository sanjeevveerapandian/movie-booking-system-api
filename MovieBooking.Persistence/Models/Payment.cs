using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Payment
{
    [Key]
    public long Id { get; set; }

    public long BookingId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [StringLength(200)]
    public string? TransactionId { get; set; }

    [StringLength(50)]
    public string? PaymentStatus { get; set; }

    public DateTime? PaidAt { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Payments")]
    public virtual Booking Booking { get; set; } = null!;
}
