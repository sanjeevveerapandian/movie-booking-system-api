using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Screen
{
    [Key]
    public long Id { get; set; }

    public long TheaterId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Screen")]
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    [InverseProperty("Screen")]
    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();

    [ForeignKey("TheaterId")]
    [InverseProperty("Screens")]
    public virtual Theater Theater { get; set; } = null!;
}
