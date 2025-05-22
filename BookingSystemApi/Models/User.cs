using System;
using System.Collections.Generic;

namespace BookingSystemApi.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool EmailConfirmed { get; set; } = false;

    public string PasswordHash { get; set; } = null!;

    public Guid SecurityStamp { get; set; } = Guid.NewGuid();
    
    public Guid ConcurrencyStamp  { get; set; } = Guid.NewGuid();

    public bool TwoFactorEnabled { get; set; } = false;

    public DateTime LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; } = false;

    public int AccessFailedCount { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }

    public int RoleId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<BookingLog> BookingLogs { get; set; } = new List<BookingLog>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RecurringBooking> RecurringBookings { get; set; } = new List<RecurringBooking>();

    public virtual Role Role { get; set; }
}