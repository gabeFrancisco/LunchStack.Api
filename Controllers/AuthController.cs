
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LunchStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            try
            {
                return Ok(await _authService.Register(userDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}