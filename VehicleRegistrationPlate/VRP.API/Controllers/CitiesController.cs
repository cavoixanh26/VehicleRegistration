using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.City;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CityRequest request) 
        {
            var response = await cityService.GetCities(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            try
            {
                var response = await cityService.GetCityById(id);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
