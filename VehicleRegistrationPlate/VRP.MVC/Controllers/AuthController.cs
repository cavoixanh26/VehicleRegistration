using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using VRP.MVC.Models.Auths;
using VRP.MVC.Repositories.HttpClient;

namespace VRP.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpCallService httpCallService;

        public AuthController(IHttpCallService httpCallService)
        {
            this.httpCallService = httpCallService;
        }

        [Route("Login")]
        public IActionResult Login(LoginRequest loginModel)
        {
            return View(loginModel);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginRequest loginModel)
        {
            try
            {
                var response = await httpCallService.PostData
                    <LoginResponse, LoginRequest>("Authentications/Login", loginModel);

                if (!string.IsNullOrEmpty(response.Token))
                {
                    Response.Cookies.Append("access_token", response.Token);
                    //var handler = new JwtSecurityTokenHandler();
                    //var jsonToken = handler.ReadToken(response.Token) as JwtSecurityToken;
                    //var rolesClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                    //TempData["isRole"] = rolesClaim.Value;
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(loginModel);
            }
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var response = await httpCallService.PostData<string, object>("Authentications/Logout", default);
            Response.Cookies.Delete("access_token");
            return RedirectToAction("Index", "Home");
        }
    }
}
