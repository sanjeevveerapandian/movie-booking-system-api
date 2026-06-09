using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Seat
{
    [Key]
    public long Id { get; set; }

    public long ScreenId { get; set; }

    [StringLength(10)]
    public string SeatNumber { get; set; } = null!;

    [StringLength(20)]
    public string SeatType { get; set; } = null!;

    [InverseProperty("Seat")]
    public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    [ForeignKey("ScreenId")]
    [InverseProperty("Seats")]
    public virtual Screen Screen { get; set; } = null!;
}
