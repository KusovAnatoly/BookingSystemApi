namespace BookingSystemApi.DTOs.Requests;

public class UserRequestDto
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public Guid SecurityStamp { get; set; }
    
    public Guid ConcurrencyStamp  { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }

    public RoleDto Role { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
}