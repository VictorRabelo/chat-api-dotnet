using ChatApi.DTOs;
using ChatApi.Models;
using ChatApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _users;
        private readonly IConfiguration _config;

        public UserService(IUserRepository users, IConfiguration config)
        {
            _users = users;
            _config = config;
        }

        public async Task<UserDto?> AuthenticateAsync(LoginRequest request)
        {
            var user = await _users.GetByUsernameAsync(request.Username);
            if (user == null) return null;
            if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt)) return null;

            return new UserDto { Id = user.Id, Username = user.Username };
        }

        public async Task<UserDto> RegisterAsync(RegisterRequest request)
        {
            var existing = await _users.GetByUsernameAsync(request.Username);
            if (existing != null) throw new InvalidOperationException("Username already taken");

            CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
            var user = new User
            {
                Username = request.Username,
                PasswordHash = hash,
                PasswordSalt = salt
            };
            await _users.AddAsync(user);
            await _users.SaveChangesAsync();
            return new UserDto { Id = user.Id, Username = user.Username };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _users.GetAllAsync();
            return users.Select(u => new UserDto { Id = u.Id, Username = u.Username });
        }

        private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computed.SequenceEqual(hash);
        }
    }
}
