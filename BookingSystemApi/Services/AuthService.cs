using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.Models;
using BookingSystemApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BookingSystemApi.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IValidator<UserRequestDto> _validator;

    public AuthService(UserManager<User> userManager, IConfiguration configuration, IValidator<UserRequestDto> validator)
    {
        _userManager = userManager;
        _configuration = configuration;
        _validator = validator;
    }

    public async Task<string> RegisterAsync(UserRequestDto model)
    {
        await _validator.ValidateAndThrowAsync(model);
        var user = new User
        {
            UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            SecondName = model.SecondName,
            CreatedAt = DateTime.UtcNow,
            RoleId = model.RoleId
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        return result.Succeeded
            ? "Пользователь успешно создан!"
            : string.Join("; ", result.Errors.Select(e => e.Description));
    }

    public async Task<string> LoginAsync(SignInRequestDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            throw new InvalidCredentialException("Некорректные данные авторизации.");

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.UtcNow.AddMonths(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}