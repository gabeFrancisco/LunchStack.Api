using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class Customer : BaseEntity
    {
       
		public required string Name { get; set; }
		public required string Phone { get; set; }
		public required string Email { get; set; }
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}