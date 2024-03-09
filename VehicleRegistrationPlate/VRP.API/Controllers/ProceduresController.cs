using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Models.Authentication;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.NumberRotatorLicensePlate;
using VRP.API.ViewModels.Procedures.VehicleInformationProcedures;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly IProcedureService procedureService;
        private readonly UserManager<AppUser> userManager;

        public ProceduresController(
            IProcedureService procedureService, 
            UserManager<AppUser> userManager)
        {
            this.procedureService = procedureService;
            this.userManager = userManager;
        }

        [HttpPost("car-license-plate")]
        public async Task<ActionResult<CarLicensePlateResponse>> RequestCarLicensePlateProcedure([FromBody] CarLicensePlateRequest request)
        {
            try
            {
                //var currentUser = this.User;
                //var userId = Guid.Parse(userManager.GetUserId(currentUser));
                var userId = Guid.Parse("FACF3BAE-F611-476A-914F-7BBCFD0C3D2D");
                var response = await procedureService.CreateCarLicensePlate(request, userId);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }

        }

        [HttpPut("car-license-plate/{id}")]
        public async Task<ActionResult> VehicleRequestCarLicensePlateProcedure(int id, [FromBody] VehicleRequest request)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                //if (currentUser == null)
                //    return Unauthorized();

                var response = await procedureService.UpdateVehicleInformation(id, request, currentUser);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpGet("{procedureId}/information-user-in-rotator")]
        public async Task<IActionResult> GetProcedureInRotator(int procedureId)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                var response = await procedureService.GetInformationUserInRotatorProcess(procedureId, currentUser);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpPut("number-license-plate")]
        public async Task<IActionResult> UpdateNumberLicensePlate([FromBody]UpdateNumberLicensePlateRequest request)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                var response = await procedureService.UpdateNumberLicensePlate(request, currentUser);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
                throw;
            }
        }
    }
}
