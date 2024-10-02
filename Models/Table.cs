using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class Table : BaseEntity
    {
        public int Number { get; set; }
		public int Chairs { get; set; }
		public bool IsBusy { get; set; }
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}