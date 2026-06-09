using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class Movie
{
    [Key]
    public long Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? DurationMinutes { get; set; }

    [StringLength(100)]
    public string? Genre { get; set; }

    [StringLength(50)]
    public string? Language { get; set; }

    public string? PosterUrl { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
