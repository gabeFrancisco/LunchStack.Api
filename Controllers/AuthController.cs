
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
            try
            {
                return Ok(await _authService.Register(userDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                return Ok(await _authService.Login(loginDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("refresh")]
        public IActionResult Refresh(string token)
        {
            try
            {
                _httpAccessor.HttpContext!.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
                Console.WriteLine(refreshToken);
                return Ok(_authService.Refresh(token, refreshToken!));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Get()
        {
            try
            {
                return Ok("God bless you!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}