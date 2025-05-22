using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.DTOs.Responses;

namespace BookingSystemApi.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserResponseDto> GetUserByIdAsync(Guid id);
    Task<UserResponseDto> GetUserByUsernameAsync(string username);
    Task<UserResponseDto> GetUserByEmailAsync(string email);
    Task AddUserAsync(UserRequestDto user);
    Task UpdateUserAsync(Guid id, UserRequestDto user);
    Task DeleteUserAsync(Guid id);
    Task<string> GetUserRoleAsync(Guid userId); // Optional
    Task<bool> UserExistsAsync(string email);
    Task<bool> UserExistsAsync(Guid id);
}