using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class BookingLog
{
    public int Id { get; set; }

    public int? BookingId { get; set; }

    public int? ChangedBy { get; set; }

    public string? Action { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual User? ChangedByNavigation { get; set; }
}
