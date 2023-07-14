using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.DTO.User;
using WorldCities.Core.ServiceContracts.User;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("filter")]
        public async Task<IActionResult> GetFilteredUsers([FromQuery] string? personName)
        {
            List<UserResponse> filteredUsers = await _userService.GetFilteredUsers(personName);
            return new JsonResult(filteredUsers);
        }
    }
}
