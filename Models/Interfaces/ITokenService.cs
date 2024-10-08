using System.Security.Claims;

namespace LunchStack.Api.Models.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username, string userId);
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        void SaveRefreshToken(string username, string refreshToken);
        string GetRefreshToken(string username);
        void DeleteRefreshToken(string username);
    }
}