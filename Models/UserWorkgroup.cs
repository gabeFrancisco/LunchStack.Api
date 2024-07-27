namespace LunchStack.Api.Models
{
    public class UserWorkgroup : BaseEntity
    {
        public virtual User? User { get; set; }
        public int UserId { get; set; }
        public virtual Workgroup? Workgroup { get; set; }
        public int WorkgroupId { get; set; }
    }
}