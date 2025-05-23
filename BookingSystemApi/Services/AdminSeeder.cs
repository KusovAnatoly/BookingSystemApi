using BookingSystemApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingSystemApi.Services;

public class AdminSeeder
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AdminSeeder(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task SeedAdminAsync()
    {
        var email = _configuration["AdminUser:Email"];
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            var username = _configuration["AdminUser:Username"];
            var role = int.Parse(_configuration["AdminUser:Role"]);
            var firstName = _configuration["AdminUser:FirstName"];
            var secondName = _configuration["AdminUser:SecondName"];
            var createdAt = DateTime.Parse(_configuration["AdminUser:CreatedAt"]).ToUniversalTime();
            var admin = new User()
            {
                UserName = username,
                RoleId = role,
                FirstName = firstName,
                SecondName = secondName,
                Email = email,
                CreatedAt = createdAt
            };
            
            var password = _configuration["AdminUser:Password"];
            await _userManager.CreateAsync(admin, password);
        }
    }
}