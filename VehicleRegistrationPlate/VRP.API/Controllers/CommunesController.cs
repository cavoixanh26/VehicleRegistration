using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRP.API.HandlingExceptions;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.Commune;

namespace VRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommunesController : ControllerBase
    {
        private readonly ICommuneService communeService;

        public CommunesController(
            ICommuneService communeService)
        {
            this.communeService = communeService;
        }

        [HttpGet]
        public async Task<ActionResult<CommuneResponse>> Gets([FromQuery]CommuneRequest request)
        {
            try
            {
                var response = await communeService.GetCommunes(request);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int) ex.Status, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommuneDto>> GetDetail(int id)
        {
            try
            {
                var response = await communeService.GetCommuneById(id);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
