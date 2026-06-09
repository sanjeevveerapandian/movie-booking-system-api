using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Show
{
    [Key]
    public long Id { get; set; }

    public long MovieId { get; set; }

    public long ScreenId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TicketPrice { get; set; }

    [InverseProperty("Show")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("MovieId")]
    [InverseProperty("Shows")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("ScreenId")]
    [InverseProperty("Shows")]
    public virtual Screen Screen { get; set; } = null!;
}
