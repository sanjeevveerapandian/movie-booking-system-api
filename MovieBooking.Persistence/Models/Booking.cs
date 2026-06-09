using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Booking
{
    [Key]
    public long Id { get; set; }

    public long UserId { get; set; }

    public long ShowId { get; set; }

    public DateTime BookingDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(50)]
    public string BookingStatus { get; set; } = null!;

    [InverseProperty("Booking")]
    public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    [InverseProperty("Booking")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [InverseProperty("Booking")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("ShowId")]
    [InverseProperty("Bookings")]
    public virtual Show Show { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Bookings")]
    public virtual User User { get; set; } = null!;
}
