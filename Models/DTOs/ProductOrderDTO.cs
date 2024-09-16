using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecantosSystem.Api.Models;

namespace LunchStack.Api.Models.DTOs
{
    public class ProductOrderDTO
    {
        public int OrderSheetId { get; set; }
        public int ProductId { get; set; }
        public required ProductDTO Product { get; set; }
		public int Quantity { get; set; }
    }
}