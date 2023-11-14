using backend.Database;
using backend.Database.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace backend.Services;

public class UserService : IUserService
{
    public readonly DatabaseContext _dbContext;
    private readonly ILogger<UserService> _logger;

    public UserService(DatabaseContext dbContext, ILogger<UserService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<OneOf<UserEntity, ApiError>> Register(AccountRegisterApiRequest request)
    {
        if (request.Password != request.PasswordConfirmation)
        {
            return new ApiError("Passwords do not match");
        }

        if (await _dbContext.Users.AnyAsync(e => e.Username == request.Username))
        {
            return new ApiError("Username is already taken");
        }

        if (await _dbContext.Users.AnyAsync(e => e.Email == request.Email))
        {
            return new ApiError("Email is already taken");
        }

        var user = new UserEntity
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<OneOf<string, ApiError>> Login(AccountLoginApiRequest request)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Username == request.Username);

        if (user == null)
        {
            await Task.Delay(2000); // Simulate a slow response to prevent timing attacks
            return new ApiError("Invalid username or password");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return new ApiError("Invalid username or password");
        }

        // Fill a 32-byte buffer with random data, and then convert it to a hex string to get a 64-character long cryptographically secure token
        string token = Utils.RandHex(64);
        string tokenHash = Utils.HashToStr(token);

        var authToken = new AuthTokenEntity
        {
            UserId = user.Id,
            TokenHash = tokenHash
        };

        await _dbContext.AuthTokens.AddAsync(authToken);
        await _dbContext.SaveChangesAsync();

        return token;
    }
}
