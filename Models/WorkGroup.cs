using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class WorkGroup : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}