using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

namespace LunchStack.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }
        public Task<dynamic> Login(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Register(UserDTO userDto)
        {
            if (userDto is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            //TODO remaining code logic block after AutoMapper install!
            return null;
        }
    }
}