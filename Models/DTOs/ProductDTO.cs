using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDTO? Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}