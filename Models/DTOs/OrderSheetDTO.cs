using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecantosSystem.Api.Models.Enums;

namespace LunchStack.Api.Models.DTOs
{
    public class OrderSheetDTO
    {
        public OrderState OrderState { get; set; }
        public int Id { get; set; }
        public int TableId { get; set; }
        public required TableDTO Table { get; set; }
		public required IEnumerable<ProductOrderDTO> ProductOrders { get; set; }
		public int? CustomerId { get; set; }
        public required CustomerDTO Customer { get; set; }
        public required string OpenBy { get; set; }
    }
}