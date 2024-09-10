namespace LunchStack.Api.Models.DTOs
{
    public class WorkgroupDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<int> Members { get; set; }
    }
}