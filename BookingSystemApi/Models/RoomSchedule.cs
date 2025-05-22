using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class RoomSchedule
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public int? DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual Room? Room { get; set; }
}
