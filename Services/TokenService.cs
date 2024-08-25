using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LunchStack.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public TokenService(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }


        public string GenerateToken(string username, string userId)
        {
            var claims = new[]{
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var createDate = _config["TokenConfiguration:ExpireSeconds"];
            var expiration = DateTime.UtcNow.AddSeconds(double.Parse(createDate!));

            var token = new JwtSecurityToken(
                issuer: _config["TokenConfiguration:Issuer"],
                audience: _config["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var createDate = _config["TokenConfiguration:ExpireSeconds"];
            var expiration = DateTime.UtcNow.AddSeconds(double.Parse(createDate!));

            var token = new JwtSecurityToken(
                issuer: _config["TokenConfiguration:Issuer"],
                audience: _config["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)),
                ValidateLifetime = false,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token!");

            return principal;
        }

        public void SaveRefreshToken(string username, string refreshToken)
        {
            _context.RefreshTokens.Add(new RefreshToken
            {
                Username = username,
                Token = refreshToken,
                CreatedAt = DateTime.UtcNow
            }
            );

            _context.SaveChanges();
        }

        public string GetRefreshToken(string username)
        {
            return _context.RefreshTokens.FirstOrDefault(rt => rt.Username == username)!.Token;
        }

        public async void DeleteRefreshToken(string username)
        {
            var dbToken = _context.RefreshTokens.FirstOrDefault(rt => rt.Username == username);
            _context.RefreshTokens.Remove(dbToken!);
            await _context.SaveChangesAsync();
        }
    }
}