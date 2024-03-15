using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRP.MVC.Models.Procedures;
using VRP.MVC.Models.Procedures.HandleProcedure;
using VRP.MVC.Repositories.HttpClient;

namespace VRP.MVC.Controllers
{
    [Route("requested-procedure")]
    public class RequestedProcedureController : Controller
    {
        private readonly IHttpCallService httpCallService;

        public RequestedProcedureController(IHttpCallService httpCallService)
        {
            this.httpCallService = httpCallService;
        }

        [Authorize(Roles = "Admin")]
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

        [HttpPost("reject-procedure")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectProcedure(RejectRequestedProcedure request)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var response = await httpCallService.PutData<ProcedureDto, RejectRequestedProcedure>
                ("RequestedProcedures/rejection-request", request);

            return Json(new {success = true});
        }

        [HttpPost("approve-procedure")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveProcedure(ApproveRequestedProcedure request)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("./Login");

            var response = await httpCallService.PutData<ProcedureDto, ApproveRequestedProcedure>
                ("RequestedProcedures/approval-request", request);

            return Json(new { success = true });
        }
    }
}
