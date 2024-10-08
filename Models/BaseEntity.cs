using System.ComponentModel.DataAnnotations;

namespace LunchStack.Api.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? UpdatedAt { get; set; }
    }
}