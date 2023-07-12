using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Identity;
using WorldCities.Core.DTO.Auth;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.ServiceContracts.Auth;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IJwtService _jwtService;

        public AccountController
            (
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtService jwtService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, registerDto.Password);

            if (identityResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                LoginResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }
            else
            {
                string errorMessage = string.Join(" | ",
                    identityResult.Errors.Select(e => e.Description));

                return Problem(errorMessage);
            }
        }


        [HttpGet]
        public async Task<IActionResult> IsEmailAlreadyExists(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Ok(true);
            }

            return Ok(false);
        }


        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            var indetityResult = await _signInManager.PasswordSignInAsync
                (loginDto.Email, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if(indetityResult.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(loginDto.Email);
                
                if(user == null)
                {
                    return NoContent();
                }

                LoginResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }

            return BadRequest("Wrong email or password");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
