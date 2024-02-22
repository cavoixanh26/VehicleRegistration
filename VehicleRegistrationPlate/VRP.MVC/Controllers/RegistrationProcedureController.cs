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
            return View();
        }

        [Route("car-license-plate")]
        public async Task<IActionResult> RegisterLicensePlate(CarLicensePlateRequest request)
        {
            return View();
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
