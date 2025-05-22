using BookingSystemApi.DTOs;
using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.Repositories.Interfaces;

namespace BookingSystemApi.Services;

public class AdminSeeder
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public AdminSeeder(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _config = config;
    }

    public async Task SeedAdminAsync()
    {
        var username = _config["AdminUser:Username"];
        var role = _config["AdminUser:Role"];
        var firstName = _config["AdminUser:FirstName"];
        var secondName = _config["AdminUser:SecondName"];
        var email = _config["AdminUser:Email"];
        var emailConfirmed = _config["AdminUser:EmailConfirmed"];
        var passwordHash = _config["AdminUser:PasswordHash"];
        var securityStamp = _config["AdminUser:SecurityStamp"];
        var concurrencyStamp = _config["AdminUser:ConcurrencyStamp"];
        var twoFactorEnabled = _config["AdminUser:TwoFactorEnabled"];
        var lockoutEnabled = _config["AdminUser:LockoutEnabled"];
        var lockoutEnd = _config["AdminUser:LockoutEnd"];
        var accessFailedCount = _config["AdminUser:AccessFailedCount"];
        var createdAt = _config["AdminUser:CreatedAt"];
        var updatedAt = _config["AdminUser:UpdatedAt"];
        var deletedAt = _config["AdminUser:DeletedAt"];
        var isDeleted = _config["AdminUser:IsDeleted"];

        if (!await _userRepository.UserExistsAsync(email))
        {
            var admin = new UserRequestDto()
            {
                Username = username,
                Role = (RoleDto)int.Parse(role),
                FirstName = firstName,
                SecondName = secondName,
                Email = email,
                EmailConfirmed = bool.Parse(emailConfirmed),
                PasswordHash = passwordHash,
                SecurityStamp = Guid.Parse(securityStamp),
                ConcurrencyStamp = Guid.Parse(concurrencyStamp),
                TwoFactorEnabled = bool.Parse(twoFactorEnabled),
                LockoutEnabled = bool.Parse(lockoutEnabled),
                LockoutEnd = DateTime.Parse(lockoutEnd),
                AccessFailedCount = int.Parse(accessFailedCount),
                CreatedAt = DateTime.Parse(createdAt),
                UpdatedAt =  DateTime.Parse(updatedAt),
                DeletedAt =  DateTime.Parse(deletedAt),
                IsDeleted =  bool.Parse(isDeleted)
            };
            
            await _userRepository.AddUserAsync(admin);
        }
    }
}