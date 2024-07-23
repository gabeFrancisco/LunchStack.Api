using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

namespace LunchStack.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AuthService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<dynamic> Login(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> Register(UserDTO userDto)
        {
            if (userDto is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            var user = _mapper.Map<UserDTO, User>(userDto);

            if (_context.Users.Any(dbUser =>
                    dbUser.Username == user.Username
                || dbUser.Email == user.Email))
            {
                throw new InvalidOperationException("Username or email already taken! Thy another one!");
            }

            string pwdHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = pwdHash;
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new
            {
                Message = $"User {user.Username} registered with success! Try login into the system."
            };
        }
    }
}