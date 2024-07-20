using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class UserWorkGroup : BaseEntity
    {
        public virtual User? User { get; set; }
        public int UserId { get; set; }
        public virtual WorkGroup? WorkGroup { get; set; }
        public int WorkGroupId { get; set; }
    }
}