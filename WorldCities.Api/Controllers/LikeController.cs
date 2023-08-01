using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Commands.Likes.AddLike;
using WorldCities.Core.Commands.Likes.RemoveLike;
using WorldCities.Core.Queries.Likes.IsAlreadyLiked;

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
            [FromRoute] Guid cityGuid,
            CancellationToken cancellationToken
        )
        {
            bool isExist = await _mediator.Send(
                new IsAlreadyLikedQuery(cityGuid),
                cancellationToken
            );

            return Ok(isExist);
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(
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
            [FromRoute] Guid cityId,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(new RemoveLikeCommand(cityId), cancellationToken);

            return Ok();
        }
    }
}
