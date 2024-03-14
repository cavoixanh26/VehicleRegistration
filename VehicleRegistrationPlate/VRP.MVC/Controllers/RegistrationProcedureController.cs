using Microsoft.AspNetCore.Mvc;
using VRP.MVC.Models.Locations.Cities;
using VRP.MVC.Models.Locations.Communes;
using VRP.MVC.Models.Locations.Districts;
using VRP.MVC.Models.Procedures;
using VRP.MVC.Repositories.HttpClient;

namespace VRP.MVC.Controllers
{
    [Route("registration")]
    public class RegistrationProcedureController : Controller
    {
        private readonly IHttpCallService httpCallService;

        public RegistrationProcedureController(IHttpCallService httpCallService)
        {
            this.httpCallService = httpCallService;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");
            return View();
        }

        [Route("car-license-plate")]
        public async Task<IActionResult> RegisterLicensePlate()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            return View();
        }

        [HttpPost]
        [Route("car-license-plate")]
        public async Task<IActionResult> RegisterLicensePlate(CarLicensePlateRequest request)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var fullName = request.InformationUser.FirstName;
            var words = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            request.InformationUser.FirstName = words[0];
            request.InformationUser.LastName = words[words.Length - 1];
            if (words.Length > 2)
            {
                var middleWords = new string[words.Length - 2];
                Array.Copy(words, 1, middleWords, 0, words.Length - 2);

                request.InformationUser.MidlleName = string.Join(" ", middleWords);
            }

            var response = await httpCallService.PostData<CarLicensePlateResponse, CarLicensePlateRequest>
                ("Procedures/car-license-plate", request);

            return RedirectToAction("Index", "Home");
        }

        [Route("cities")]
        public async Task<ActionResult> GetCities(int? districtId, int? communeId)
        {
            var cityRequest = new CityRequest();
            var citiesResponse = await httpCallService.GetData<CityResponse>("Cities", cityRequest);
            return Json(citiesResponse.Cities);
        }

        [Route("districts")]
        public async Task<ActionResult> GetDistricts(int? cityId, int? communeId)
        {
            var districtRequest = new DistrictRequest();
            if (cityId.HasValue)
                districtRequest.CityId = cityId;

            var districtsResponse = await httpCallService.GetData<DistrictResponse>("Districts", districtRequest);
            return Json(districtsResponse.Districts);
        }

        [Route("communes")]
        public async Task<ActionResult> GetCommunes(int? cityId, int? districtId)
        {
            var communeRequest = new CommuneRequest();
            if (districtId.HasValue)
                communeRequest.DistrictId = districtId;

            var communesResponse = await httpCallService.GetData<CommuneResponse>("Communes", communeRequest);
            return Json(communesResponse.Communes);
        }
    }
}
