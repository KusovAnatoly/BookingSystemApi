using BookingSystemApi.Data;
using BookingSystemApi.DTOs;
using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.DTOs.Responses;
using BookingSystemApi.Models;
using BookingSystemApi.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ILogger _logger;
    private readonly BookingDatabaseContext _context;
    private readonly IValidator<UserRequestDto> _validator;

    public UserRepository(BookingDatabaseContext context, IValidator<UserRequestDto> validator,  ILogger<UserRepository> logger)
    {
        _context = context;
        _validator = validator;
        _logger = logger;
    }

    public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
    {
        return await _context.Users
            .Include(ur => ur.Role)
            .Where(u => u.Id == id)
            .Where(u => !u.IsDeleted)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = (RoleDto)u.RoleId,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                PasswordHash = u.PasswordHash,
                SecurityStamp = u.SecurityStamp,
                ConcurrencyStamp = u.ConcurrencyStamp,
                TwoFactorEnabled = u.TwoFactorEnabled,
                LockoutEnabled = u.LockoutEnabled,
                LockoutEnd = u.LockoutEnd,
                AccessFailedCount = u.AccessFailedCount,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                DeletedAt = u.DeletedAt,
                IsDeleted = u.IsDeleted
            })
            .FirstOrDefaultAsync() ?? throw new Exception($"Пользователь с ID {id} не был найден.");
    }

    public async Task<UserResponseDto> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Role)
            .Where(u => u.Username.ToLower() == username.ToLower())
            .Where(u => !u.IsDeleted)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = (RoleDto)u.RoleId,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                PasswordHash = u.PasswordHash,
                SecurityStamp = u.SecurityStamp,
                ConcurrencyStamp = u.ConcurrencyStamp,
                TwoFactorEnabled = u.TwoFactorEnabled,
                LockoutEnabled = u.LockoutEnabled,
                LockoutEnd = u.LockoutEnd,
                AccessFailedCount = u.AccessFailedCount,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                DeletedAt = u.DeletedAt,
                IsDeleted = u.IsDeleted
            })
            .FirstOrDefaultAsync() ?? throw new Exception($"Пользователь с пользовательским именем {username} не был найден.");
    }

    public async Task<UserResponseDto> GetUserByEmailAsync(string email)
    {
           
        return await _context.Users
            .Include(u => u.Role)
            .Where(u => u.Email.ToLower() == email.ToLower())
            .Where(u => !u.IsDeleted)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = (RoleDto)u.RoleId,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                PasswordHash = u.PasswordHash,
                SecurityStamp = u.SecurityStamp,
                ConcurrencyStamp = u.ConcurrencyStamp,
                TwoFactorEnabled = u.TwoFactorEnabled,
                LockoutEnabled = u.LockoutEnabled,
                LockoutEnd = u.LockoutEnd,
                AccessFailedCount = u.AccessFailedCount,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                DeletedAt = u.DeletedAt,
                IsDeleted = u.IsDeleted
            })
            .FirstOrDefaultAsync() ?? throw new Exception($"Пользователь с электронной почтой {email} не был найден.");
    }

    public async Task AddUserAsync(UserRequestDto userRequestDto)
    {
        await _validator.ValidateAndThrowAsync(userRequestDto);

        var user = new User
        {
            Username = userRequestDto.Username,
            RoleId = (int)userRequestDto.Role,
            FirstName = userRequestDto.FirstName,
            SecondName = userRequestDto.SecondName,
            Email = userRequestDto.Email,
            EmailConfirmed = userRequestDto.EmailConfirmed,
            PasswordHash = userRequestDto.PasswordHash,
            SecurityStamp = userRequestDto.SecurityStamp,
            ConcurrencyStamp = userRequestDto.ConcurrencyStamp,
            TwoFactorEnabled = userRequestDto.TwoFactorEnabled,
            LockoutEnabled = userRequestDto.LockoutEnabled,
            LockoutEnd = userRequestDto.LockoutEnd,
            AccessFailedCount = userRequestDto.AccessFailedCount,
            CreatedAt = userRequestDto.CreatedAt,
            UpdatedAt = userRequestDto.UpdatedAt,
            DeletedAt = userRequestDto.DeletedAt,
            IsDeleted = userRequestDto.IsDeleted
        };

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            throw;
        }
    }


    public async Task UpdateUserAsync(Guid id, UserRequestDto userRequestDto)
    {
        await _validator.ValidateAndThrowAsync(userRequestDto);
        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
        {
            throw new Exception($"Пользователь с ID {id} не был найден.");
        }
        
        user.Username = userRequestDto.Username;
        user.RoleId = (int)userRequestDto.Role;
        user.FirstName = userRequestDto.FirstName;
        user.SecondName = userRequestDto.SecondName;
        user.Email = userRequestDto.Email;
        user.EmailConfirmed = userRequestDto.EmailConfirmed;
        user.PasswordHash = userRequestDto.PasswordHash;
        user.SecurityStamp = userRequestDto.SecurityStamp;
        user.ConcurrencyStamp = userRequestDto.ConcurrencyStamp;
        user.TwoFactorEnabled = userRequestDto.TwoFactorEnabled;
        user.LockoutEnabled = userRequestDto.LockoutEnabled;
        user.LockoutEnd = userRequestDto.LockoutEnd;
        user.AccessFailedCount = userRequestDto.AccessFailedCount;
        user.CreatedAt = userRequestDto.CreatedAt;
        user.UpdatedAt = userRequestDto.UpdatedAt;
        user.DeletedAt = userRequestDto.DeletedAt;
        user.IsDeleted = userRequestDto.IsDeleted;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            throw;
        }
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user != null)
        {
            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }

    public async Task<string> GetUserRoleAsync(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == id);
        
        if (user is null)
        {
            throw new Exception($"Пользователь с ID {id} не был найден.");
        }
        
        return user.Role.Name;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> UserExistsAsync(Guid id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }
    
}