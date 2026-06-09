using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class BookingSeat
{
    [Key]
    public long Id { get; set; }

    public long BookingId { get; set; }

    public long SeatId { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("BookingSeats")]
    public virtual Booking Booking { get; set; } = null!;

    [ForeignKey("SeatId")]
    [InverseProperty("BookingSeats")]
    public virtual Seat Seat { get; set; } = null!;
}
