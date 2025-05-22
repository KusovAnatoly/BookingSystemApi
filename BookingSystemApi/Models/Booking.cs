using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? Status { get; set; }

    public int? RecurringId { get; set; }

    public virtual ICollection<BookingLog> BookingLogs { get; set; } = new List<BookingLog>();

    public virtual RecurringBooking? Recurring { get; set; }

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
