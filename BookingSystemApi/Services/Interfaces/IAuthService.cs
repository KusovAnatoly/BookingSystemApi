using BookingSystemApi.DTOs.Requests;

namespace BookingSystemApi.Services.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(UserRequestDto model);
    Task<string> LoginAsync(SignInRequestDto model);
}