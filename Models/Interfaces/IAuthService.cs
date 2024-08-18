using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IAuthService
    {
        Task<dynamic> Register(UserDTO userDto);
        Task<dynamic> Login(LoginDTO loginDto);
        dynamic Refresh(string token, string refreshToken);
    }
}