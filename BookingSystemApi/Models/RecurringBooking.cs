using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class RecurringBooking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public string? Frequency { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
