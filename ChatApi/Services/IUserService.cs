using ChatApi.DTOs;
using ChatApi.Models;

namespace ChatApi.Services
{
    public interface IUserService
    {
        Task<UserDto?> AuthenticateAsync(LoginRequest request);
        Task<UserDto> RegisterAsync(RegisterRequest request);
        Task<IEnumerable<UserDto>> GetAllAsync();
    }
}
