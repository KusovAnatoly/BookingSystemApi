using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRequestDto model)
    {
        var result = await _authService.RegisterAsync(model);
        return Ok(new { message = result });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(SignInRequestDto model)
    {
        var token = await _authService.LoginAsync(model);
        return Ok(new { token });
    }
}