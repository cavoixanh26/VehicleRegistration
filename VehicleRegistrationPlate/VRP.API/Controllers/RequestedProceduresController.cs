using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Models.Authentication;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.HanldeRequest;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestedProceduresController : ControllerBase
    {
        private readonly IProcedureService procedureService;
        private readonly UserManager<AppUser> userManager;

        public RequestedProceduresController(
            IProcedureService procedureService,
            UserManager<AppUser> userManager)
        {
            this.procedureService = procedureService;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<ProcedureResponse>> GetProcedures([FromQuery] ProcedureRequest request)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser == null)
                    return Unauthorized();

                var response = await procedureService.GetProcedures(request, currentUser);
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
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser == null)
                    return Unauthorized();

                var response = await procedureService.GetUserInformationProcedureById(id, currentUser);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpPut("approval-request")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveRequest([FromBody] ApproveRequestedProcedure request)
        {
            try
            {
                var response = await procedureService.ApproveRequestedProcedure(request);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int) ex.Status, ex.Message);
            }
        }

        [HttpPut("rejection-request")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRequest([FromBody] RejectRequestedProcedure request)
        {
            try
            {
                var response = await procedureService.RejectRequestProcedure(request);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
