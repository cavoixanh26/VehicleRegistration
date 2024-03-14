using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.Repositories.IServices.Vehicles;
using VRP.API.ViewModels.Vehicles;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly ITypeOfVehicleService typeOfVehicleService;

        public VehicleController(ITypeOfVehicleService typeOfVehicleService)
        {
            this.typeOfVehicleService = typeOfVehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await typeOfVehicleService.GetTypeVehicles();
            return Ok(response);
        }

        [HttpGet("exist-license-plate")]
        public async Task<IActionResult> GetAllExistLicensePlate([FromQuery]NumberLicensePlateRequest request)
        {
            var  response = await typeOfVehicleService.GetExistNumberLicensePlate(request);

            return Ok(response);
        }
    }
}
