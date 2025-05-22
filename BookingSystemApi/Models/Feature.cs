using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class Feature
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
