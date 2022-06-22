using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrtProjectTemplate.API.Middleware;
using MrtProjectTemplate.Models.User;
using MrtProjectTemplate.Services.User;

namespace MrtProjectTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        /// <summary>
        /// login
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public IActionResult LoginAsync(UserRequest userRequest) => Ok(_userService.GenerateJwtToken(userRequest));

        /// <summary>
        /// userlist
        /// </summary>
        /// <param name="userAllRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("userlist")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListUsersAsync(UserListRequest userAllRequest) => Ok(await _userService.GetListUserAsync(userAllRequest));
      
        /// <summary>
        /// Pings
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("ping")]
        public IActionResult Pings()
        {
            return Ok("Success");
        }
    }
}
