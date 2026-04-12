using IclPaths.API.Domain.Interfaces.AuthInterfaces;
using IclPaths.API.Domain.Repositories.AuthRepository;
using IclPaths.API.Models.DTO.AuthDTOs.Login;
using IclPaths.API.Models.DTO.AuthDTOs.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                var invalidRoles = new List<string>();

                foreach (var role in registerRequestDto.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        invalidRoles.Add(role);
                    }
                }

                if (invalidRoles.Any())
                {
                    return BadRequest(new
                    {
                        message = "Invalid roles",
                        roles = invalidRoles
                    });
                }
            }

            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                var roleResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (!roleResult.Succeeded)
                {
                    return BadRequest(roleResult.Errors);
                }
            }

            return Ok("User registered successfully!");
        }


        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Login);
            if (user != null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (isPasswordValid)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }
            return BadRequest("Invalid login or password.");
        }
    }
}
