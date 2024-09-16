using System.ComponentModel.DataAnnotations;

namespace LunchStack.Api.Models.DTOs
{
    public class TableDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
		public int Chairs { get; set; }
        public bool IsBusy { get; set; }
    }
}