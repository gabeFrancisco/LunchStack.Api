using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LunchStack.Api.Models
{
    public class Product : BaseEntity
    {
		[MaxLength(50)]
		public required string Name { get; set; }
		public int CategoryId { get; set; }
		public required virtual Category Category { get; set; }
		public int Quantity { get; set; }

		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }
		public required virtual Workgroup Workgroup { get; set; }
		public int WorkgroupId { get; set; }
    }
}