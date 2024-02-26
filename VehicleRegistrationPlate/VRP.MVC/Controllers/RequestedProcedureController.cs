using Microsoft.AspNetCore.Mvc;
using VRP.MVC.Models.Procedures;
using VRP.MVC.Repositories.HttpClient;

namespace VRP.MVC.Controllers
{
    public class RequestedProcedureController : Controller
    {
        private readonly IHttpCallService httpCallService;

        public RequestedProcedureController(IHttpCallService httpCallService)
        {
            this.httpCallService = httpCallService;
        }

        public async Task<IActionResult> Index()
        {
            var requestedProcedureRequest = new ProcedureRequest();
            var response = await httpCallService.GetData<ProcedureResponse>("RequestedProcedures", requestedProcedureRequest);
            return View(response);
        }
    }
}
