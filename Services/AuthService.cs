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
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthService(AppDbContext context, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContext, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContext = httpContext;
            _userService = userService;
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

            var token = _tokenService.GenerateToken(user.Username, user.Id.ToString());
            _httpContext.HttpContext!.Response.Cookies.Append("refreshToken", token, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return new
            {
                User = user,
                Token = token,
                Message = $"The user {user.Username} is logged succesfully!"
            };
        }

        public async Task<dynamic> Register(UserDTO userDto)
        {
            if (userDto is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            await _userService.CreateAsync(userDto);

            return new
            {
                Message = $"User {userDto.Username} registered with success! Try login into the system."
            };
        }
    }
}
