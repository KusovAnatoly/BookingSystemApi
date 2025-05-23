using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class Notification
{
    public Guid Id { get; set; }

    public string? UserId { get; set; }

    public string Message { get; set; } = null!;

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
