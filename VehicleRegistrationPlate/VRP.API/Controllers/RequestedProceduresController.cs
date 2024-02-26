using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.ViewModels.Procedures;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedProceduresController : ControllerBase
    {
        private readonly IProcedureService procedureService;

        public RequestedProceduresController(IProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }
        [HttpGet]
        public async Task<ActionResult<ProcedureResponse>> GetProcedures([FromQuery] ProcedureRequest request)
        {
            try
            {
                var response = await procedureService.GetProcedures(request);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int) ex.Status, ex.Message);
            }          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcedureById(int id)
        {
            try
            {
                var response = await procedureService.GetUserInformationProcedureById(id);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
