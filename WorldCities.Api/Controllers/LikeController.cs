using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WorldCities.Core.Commands.Likes.AddLike;
using WorldCities.Core.Commands.Likes.Models;
using WorldCities.Core.Commands.Likes.RemoveLike;
using WorldCities.Core.Queries.Likes.IsAlreadyLiked;
using WorldCities.Infrastructure.Hubs;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid,
            [FromBody] AddLikeCommand command,
            CancellationToken cancellationToken
        )
        {
            LikeDto like = await _mediator.Send(command, cancellationToken);
            return new JsonResult(like);
        }

        [Route("{cityGuid:guid}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveLike(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid,
            [FromRoute] Guid cityGuid,
            CancellationToken cancellationToken
        )
        {
            Guid deletedLikeId = await _mediator.Send(
                new RemoveLikeCommand(userGuid, cityGuid),
                cancellationToken
            );

            return Ok(deletedLikeId);
        }

        [Route("is-already-liked/{cityGuid:guid}")]
        [HttpGet]
        [Authorize]
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
    }
}
