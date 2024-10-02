using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecantosSystem.Api.Models.Enums;

namespace LunchStack.Api.Models
{
    public class OrderSheet : BaseEntity
    {
        public OrderState OrderState { get; set; }
		public int TableId { get; set; }
		public required virtual Table Table { get; set; }
		public required IEnumerable<ProductOrder> ProductOrders { get; set; }
		public int CustomerId { get; set; }
		public required virtual Customer Customer { get; set; }
		public required string OpenBy { get; set; }
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}