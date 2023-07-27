using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Commands.Likes.AddLike;
using WorldCities.Core.Commands.Likes.RemoveLike;
using WorldCities.Core.Queries.Likes.IsAlreadyLiked;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("is-already-liked/{cityGuid:guid}")]
        [HttpGet]
        public async Task<IActionResult> IsCityAlreadyLiked(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid,
            [FromRoute] Guid cityGuid,
            CancellationToken cancellationToken
        )
        {
            bool isExist = await _mediator.Send(
                new IsAlreadyLikedQuery(userGuid, cityGuid),
                cancellationToken
            );

            return Ok(isExist);
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid,
            [FromBody] AddLikeCommand command,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [Route("{cityId:guid}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userId,
            [FromRoute] Guid cityId,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(new RemoveLikeCommand(userId, cityId), cancellationToken);

            return Ok();
        }
    }
}
