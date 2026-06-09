using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Theater
{
    [Key]
    public long Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(20)]
    public string? PinCode { get; set; }

    public long OwnerId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("Theaters")]
    public virtual User Owner { get; set; } = null!;

    [InverseProperty("Theater")]
    public virtual ICollection<Screen> Screens { get; set; } = new List<Screen>();
}
