using ChatApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _users;
        public UsersController(IUserService users)
        {
            _users = users;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _users.GetAllAsync();
            return Ok(users);
        }
    }
}
