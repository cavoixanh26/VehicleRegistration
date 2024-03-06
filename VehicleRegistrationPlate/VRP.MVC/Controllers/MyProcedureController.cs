using Microsoft.AspNetCore.Mvc;
using VRP.MVC.Models.Procedures;
using VRP.MVC.Models.Procedures.VehicleInformations;
using VRP.MVC.Models.TypeOfVehicles;
using VRP.MVC.Repositories.HttpClient;

namespace VRP.MVC.Controllers
{
    [Route("my-procedure")]
    public class MyProcedureController : Controller
    {
        private readonly IHttpCallService httpCallService;

        public MyProcedureController(IHttpCallService httpCallService)
        {
            this.httpCallService = httpCallService;
        }
        public async Task<IActionResult> Index()
        {
            var requestedProcedureRequest = new ProcedureRequest();
            var response = await httpCallService.GetData<ProcedureResponse>("RequestedProcedures", requestedProcedureRequest);
            return View(response);
        }

        [Route("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var response = await httpCallService.GetData<RequestedProcedure>($"RequestedProcedures/{id}", null);
            return View(response);
        }

        [Route("type-of-vehicle")]
        public async Task<IActionResult> GetTypeOfVehicle()
        {
            var response = await httpCallService.GetData<List<TypeOfVehicle>>("Vehicle", null);
            return Json(response);
        }

        [Route("update-vehicle-information")]
        [HttpPost]
        public async Task<IActionResult> UpdateVehicle(int procedureId, VehicleRequest request)
        {
            var response = await httpCallService
                .PutData<RequestedProcedure, VehicleRequest>
                ($"Procedures/car-license-plate/{procedureId}", request);
            return Json(response);
        }


        [Route("{procedureId}/number-rotator")]
        [HttpGet]
        public async Task<IActionResult> RotatorNumberLicensePlate(int procedureId)
        {
            return View();
        }
    }
}
