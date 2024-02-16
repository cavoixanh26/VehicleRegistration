using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.District;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService districtService;

        public DistrictsController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }

        [HttpGet]
        public async Task<ActionResult<DistrictResponse>> Gets([FromQuery] DistrictRequest request)
        {
            try
            {
                var response = await districtService.GetDistricts(request);
                return Ok(response);    
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictDto>> GetDetail(int id)
        {
            try
            {
                var response = await districtService.GetDistrictById(id);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
