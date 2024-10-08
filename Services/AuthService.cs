using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LunchStack.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthService(AppDbContext context,
                           IMapper mapper,
                           ITokenService tokenService,
                           IHttpContextAccessor httpContext,
                           IUserService userService)
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
                .AsNoTracking()
                .Where(x => x.Username == loginDto.Username)
                .SingleOrDefaultAsync() ?? throw new NullReferenceException("Username is incorrect!");

            bool verified = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
            if (!verified)
            {
                throw new InvalidOperationException("Password is incorrect!");
            }

            var token = _tokenService.GenerateToken(user.Username, user.Id.ToString());
            var refreshToken = _tokenService.GenerateRefreshToken();
            _tokenService.DeleteRefreshToken(user.Username);
            _tokenService.SaveRefreshToken(user.Username, refreshToken);

            _httpContext.HttpContext!.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMonths(6),
            });

             _httpContext.HttpContext!.Response.Cookies.Append("accessToken", token, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMonths(6),
            });

            var userDto = _mapper.Map<User, UserDTO>(user);
            userDto.Password = "";

            return new
            {
                User = userDto,
                Token = token,
                Message = $"The user {user.Username} is logged succesfully!"
            };
        }

        public dynamic Refresh(string token, string refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity!.Name!;
            var savedRefreshToken = _tokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");


            var newJwtToken = _tokenService.GenerateToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            _tokenService.DeleteRefreshToken(username);
            _tokenService.SaveRefreshToken(username, newRefreshToken);

            _httpContext.HttpContext!.Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMonths(6),
            });

             _httpContext.HttpContext!.Response.Cookies.Append("accessToken", newJwtToken, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMonths(6),
            });

            return new
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
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
