using Microsoft.AspNetCore.Mvc;
using VRP.API.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using VRP.API.ViewModels.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using VRP.API.ConfigureSettings;
using Microsoft.AspNetCore.Authorization;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly JwtSetting jwtSetting;
        private readonly SignInManager<AppUser> signInManager;

        public AuthenticationsController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IOptions<JwtSetting> jwtSetting,
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtSetting = jwtSetting.Value;
            this.signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            var checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret));

                var token = new JwtSecurityToken(
                    issuer: jwtSetting.ValidIssuer,
                    audience: jwtSetting.ValidAudience,
                    expires: DateTime.Now.AddDays(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Ok("Logout successfully");
        }

    }
}
