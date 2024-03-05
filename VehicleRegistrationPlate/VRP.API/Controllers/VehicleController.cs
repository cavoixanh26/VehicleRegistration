using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.Repositories.IServices.Vehicles;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
