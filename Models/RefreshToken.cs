using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models
{
    public class RefreshToken
    {
        public required string Username { get; set; }
        public required string Token { get; set; }
    }
}