using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WorldCities.Infrastructure.Hubs;

namespace WorldCities.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HealthCheckController : ControllerBase
    {
        private IHubContext<HealthCheckHub> _hub;

        public HealthCheckController(IHubContext<HealthCheckHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            await _hub.Clients.All.SendAsync("Update", "test");
            return Ok("Update message sent.");
        }

        [HttpGet]
        public async Task<IActionResult> ClientUpdate()
        {
            await _hub.Clients.All.SendAsync("ClientUpdate", "test");
            return Ok("Update message sent.");
        }
    }
}
