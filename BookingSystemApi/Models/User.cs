using Microsoft.AspNetCore.Identity;

namespace BookingSystemApi.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    

    public DateTime? UpdatedAt { get; set; }

    public int RoleId { get; set; }
    

    public bool IsDeleted { get; set; } = false;
    

    public DateTime? DeletedAt { get; set; }
    
    public virtual ICollection<BookingLog> BookingLogs { get; set; } = new List<BookingLog>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RecurringBooking> RecurringBookings { get; set; } = new List<RecurringBooking>();

}