namespace LunchStack.Api.Models.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username, string userId);
        string GenerateRefreshToken();
    }
}