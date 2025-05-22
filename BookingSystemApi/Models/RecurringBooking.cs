using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class RecurringBooking
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? RoomId { get; set; }

    public string? Frequency { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
