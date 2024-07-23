using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

namespace LunchStack.Api.Services
{
    public class AuthService : IAuthService
    {
        public Task<dynamic> Login(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Register(UserDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}