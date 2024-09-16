using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string Color { get; set; }
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}