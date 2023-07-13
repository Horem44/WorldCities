using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("me")]
        [Authorize]
        public IActionResult GetUserId()
        {
            var userId = User.FindFirst("sub")?.Value;

            return Ok(new { UserId = userId });
        }
    }
}
