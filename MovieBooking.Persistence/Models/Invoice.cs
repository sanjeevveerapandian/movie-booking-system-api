using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

[Index("InvoiceNumber", Name = "UQ__Invoices__D776E98126173924", IsUnique = true)]
public partial class Invoice
{
    [Key]
    public long Id { get; set; }

    public long BookingId { get; set; }

    [StringLength(100)]
    public string? InvoiceNumber { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? PdfUrl { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Invoices")]
    public virtual Booking Booking { get; set; } = null!;
}
