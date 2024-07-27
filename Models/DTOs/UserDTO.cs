using LunchStack.Api.Models.Enums;

namespace LunchStack.Api.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Role Role { get; set; }
    }
}