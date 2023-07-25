using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.DTO.Auth;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Identity;
using WorldCities.Infrastructure.ActionFilters;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IJwtService _jwtService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtService jwtService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateModelState]
        public async Task<ActionResult<AuthResponse>> Register(RegisterDto registerDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerDto.Email,
                PersonName = registerDto.PersonName,
                Email = registerDto.Email,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(
                user,
                registerDto.Password
            );

            if (identityResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                AuthResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }
            else
            {
                string errorMessage = string.Join(
                    " | ",
                    identityResult.Errors.Select(e => e.Description)
                );

                return Problem(errorMessage);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailAlreadyExists(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateModelState]
        public async Task<ActionResult<ApplicationUser>> Login(LoginDto loginDto)
        {
            var indetityResult = await _signInManager.PasswordSignInAsync(
                loginDto.Email,
                loginDto.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (indetityResult.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    return NoContent();
                }

                AuthResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }

            return BadRequest("Wrong email or password");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> authenticate(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid
        )
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userGuid.ToString());

            if (user == null)
            {
                return Ok(false);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            AuthResponse authenticationResponse = _jwtService.CreateJwtToken(user);

            return Ok(authenticationResponse);
        }
    }
}
