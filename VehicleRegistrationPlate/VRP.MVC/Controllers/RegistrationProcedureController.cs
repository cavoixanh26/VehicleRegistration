using Microsoft.AspNetCore.Mvc;

namespace VRP.MVC.Controllers
{
    [Route("registration")]
    public class RegistrationProcedureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("car-license-plate")]
        public IActionResult RegisterLicensePlate()
        {
            return View();
        }
    }
}
