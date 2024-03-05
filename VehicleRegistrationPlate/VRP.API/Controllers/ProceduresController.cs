using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Models.Authentication;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.ViewModels.Procedures;

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
                var userId = Guid.Parse("66127FC8-3167-403E-8F39-7880AED4FF33");
                var response = await procedureService.CreateCarLicensePlate(request, userId);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }

        }
    }
}
