using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Api.ActionFilters;
using WorldCities.Core.Commands.Users.AuthorizeUser;
using WorldCities.Core.Commands.Users.LoginUser;
using WorldCities.Core.Commands.Users.Models;
using WorldCities.Core.Commands.Users.RegisterUser;
using WorldCities.Core.Queries.Users.IsEmailAlreadyExists;
using WorldCities.Core.Queries.Users.LogoutUser;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Authorize()
        {
            UserDto userDto = await _mediator.Send(new AuthorizeUserCommand());
            return new JsonResult(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutUserQuery());
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> IsEmailAlreadyExists(IsEmailAlreadyExistsQuery query)
        {
            bool isExists = await _mediator.Send(query);
            return Ok(isExists);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<ActionResult> Login(
            LoginUserCommand command,
            CancellationToken cancellationToken
        )
        {
            UserDto userDto = await _mediator.Send(command, cancellationToken);
            return new JsonResult(userDto);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<ActionResult> Register(
            RegisterUserCommand command,
            CancellationToken cancellationToken
        )
        {
            UserDto userDto = await _mediator.Send(command, cancellationToken);
            return new JsonResult(userDto);
        }
    }
}
