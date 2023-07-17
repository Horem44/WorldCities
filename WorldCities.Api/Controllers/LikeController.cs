using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Like;
using WorldCities.Core.ServiceContracts.Like;
using WorldCities.Infrastructure.Hubs;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly IHubContext<CityHub> _hub;

        public LikeController(ILikeService likeService, IHubContext<CityHub> hub)
        {
            _likeService = likeService;
            _hub = hub;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid, LikeDto likeDto)
        {
            LikeResponse like = await _likeService.AddLike(userGuid, likeDto.CityGuid);
            return new JsonResult(like);
        }

        [Route("{cityGuid:guid}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid, [FromRoute] Guid cityGuid
            )
        {
            await _likeService.RemoveLike(userGuid, cityGuid);  
            return Ok();
        }

        [Route("is-already-liked/{cityGuid:guid}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> IsCityAlreadyLiked(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid, [FromRoute] Guid cityGuid
            )
        {
            bool isExist = await _likeService.IsAlreadyExists(userGuid, cityGuid);
            return Ok(isExist);
        }
    }
}
