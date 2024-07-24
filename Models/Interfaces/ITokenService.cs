using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchStack.Api.Models.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username, string userId);
    }
}