using System.ComponentModel.DataAnnotations;

namespace LunchStack.Api.Models.DTOs
{
	public class CustomerDTO
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Phone { get; set; }
		public required string Email { get; set; }
	}
}