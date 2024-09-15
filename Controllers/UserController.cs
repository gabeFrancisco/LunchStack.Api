using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LunchStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("actualUser")]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetActualUser();
            user.Password = "";
            return Ok(user);
        }
    }
}