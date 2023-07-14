using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.DTO.Like;
using WorldCities.Core.ServiceContracts.Like;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid, LikeDto likeDto)
        {
            await _likeService.AddLike(userGuid, likeDto.CityGuid);
            return Ok();
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
    }
}
