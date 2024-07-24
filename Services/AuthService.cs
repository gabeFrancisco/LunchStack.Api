using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunchStack.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthService(AppDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<dynamic> Login(LoginDTO loginDto)
        {
            if (loginDto is null)
            {
                throw new NullReferenceException("Login data cannot be null!");
            }

            var user = await _context.Users
                .Where(x => x.Username == loginDto.Username)
                .SingleOrDefaultAsync() ?? throw new NullReferenceException("Username is incorrect!");

            bool verified = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
            if (!verified)
            {
                throw new InvalidOperationException("Password is incorrect!");
            }

            user.Password = "";

            return new
            {
                User = user,
                Token = _tokenService.GenerateToken(user.Username, user.Id.ToString()),
                Message = $"The user {user.Username} is logged succesfully!"
            };
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