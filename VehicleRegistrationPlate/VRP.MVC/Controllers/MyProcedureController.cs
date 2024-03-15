using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRP.MVC.Models.Procedures;
using VRP.MVC.Models.Procedures.RotatorNumber;
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
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var requestedProcedureRequest = new ProcedureRequest();
            var response = await httpCallService.GetData<ProcedureResponse>("RequestedProcedures", requestedProcedureRequest);
            return View(response);
        }

        [Route("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

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
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var response = await httpCallService
                .PutData<RequestedProcedure, VehicleRequest>
                ($"Procedures/car-license-plate/{procedureId}", request);
            return RedirectToAction("GetDetail", new {id = procedureId});
        }


        [Route("{procedureId}/number-rotator")]
        [HttpGet]
        public async Task<IActionResult> RotatorNumberLicensePlate(int procedureId)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var response = await httpCallService.GetData<InformationLicensePlate>($"Procedures/{procedureId}/information-user-in-rotator", null);
            return View(response);
        }

        [Route("update-number-license-plate")]
        [HttpPost]
        public async Task<IActionResult> UpdateNumberLicensePlate([FromBody]UpdateNumberLicensePlateRequest request)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var response = await httpCallService.PutData<VehicleInformation, UpdateNumberLicensePlateRequest>
                ("Procedures/number-license-plate", request);
            return Json(response);
        }

        [Route("cancel-procedure")]
        [HttpPost]
        public async Task<IActionResult> CancelProcedure(int procedureId)
        {
            await httpCallService.PutData<string, object>($"Procedures/{procedureId}/cancel-procedure", default);
            return RedirectToAction(nameof(MyProcedureController.Index));
        }
    }
}
