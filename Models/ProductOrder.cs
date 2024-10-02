using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class ProductOrder : BaseEntity
    {
        public int OrderSheetId { get; set; }
		public virtual OrderSheet? OrderSheet { get; set; }
		public int ProductId { get; set; }
		public required virtual Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Total
		{
			get => Quantity * Product.Price;
		}
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}