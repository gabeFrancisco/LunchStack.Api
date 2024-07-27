namespace LunchStack.Api.Models
{
    public class Workgroup : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}