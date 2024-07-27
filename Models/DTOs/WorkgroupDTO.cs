namespace LunchStack.Api.Models.DTOs
{
    public class WorkgroupDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<Guid> Members { get; set; }
    }
}