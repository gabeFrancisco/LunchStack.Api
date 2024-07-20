using LunchStack.Api.Models.Enums;

namespace LunchStack.Api.Models
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Role Role { get; set; }
        public IEnumerable<UserWorkGroup>? UserWorkGroups { get; set; }
        public int LastUserWorkGroup { get; set; }
    }
}
