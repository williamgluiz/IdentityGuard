using IdentityGuard.Data.DTO.Login;
using IdentityGuard.Data.DTO.User;
using IdentityGuard.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityGuard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(CreateUserDTO userDTO)
        {
            await _userService.Register(userDTO);

            return Ok("Registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDTO loginUserDTO)
        {
            var token = await _userService.Login(loginUserDTO);
            return Ok(token);
        }
    }
}
