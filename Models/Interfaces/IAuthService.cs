using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IAuthService
    {
        Task<dynamic> Register(UserDTO userDto);
        Task<dynamic> Login(LoginDTO loginDto);
    }
}