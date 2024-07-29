using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models.DTOs
{
    public class AuthDTO
    {
        public required UserDTO UserDTO { get; set; }
        public required string RefreshToken { get; set; }
        public required DateTime RefreshTokenExpiryTime { get; set; }
    }
}