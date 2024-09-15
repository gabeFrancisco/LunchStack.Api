
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LunchStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpAccessor;
        public AuthController(IAuthService authService, IHttpContextAccessor httpAccessor)
        {
            _authService = authService;
            _httpAccessor = httpAccessor;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            return Ok(await _authService.Register(userDto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            return Ok(await _authService.Login(loginDto));
        }
        [HttpPost("refresh")]
        public IActionResult Refresh(string token)
        {
            _httpAccessor.HttpContext!.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
            Console.WriteLine("RT: " + refreshToken);
            return Ok(_authService.Refresh(token, refreshToken!));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Get()
        {
            return Ok("God blss you!");
        }


    }
}