using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Persistence.Models;

public partial class EmailLog
{
    [Key]
    public long Id { get; set; }

    public long? UserId { get; set; }

    [StringLength(500)]
    public string? Subject { get; set; }

    [StringLength(255)]
    public string? EmailAddress { get; set; }

    public DateTime? SentAt { get; set; }

    public bool? IsSuccess { get; set; }
}
