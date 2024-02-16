using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRP.API.Extensions;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.City;

namespace VRP.API.Repositories.Services.Locations
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;

        public CityService(
            ApplicationDbcontext context, 
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CityResponse> GetCities(CityRequest request)
        {
            var cities = await context.Cities
                .Where(x => string.IsNullOrEmpty(request.KeyWords)
                        || x.Name.Contains(request.KeyWords))
                .ToListAsync();
            var cityDtos = mapper.Map<List<CityDto>>(cities.Paginate(request));
            return new CityResponse
            {
                Cities = cityDtos,
                Page = request.GetPagingResponse(cities.Count())
            };
        }

        public async Task<CityDto> GetCityById(int id)
        {
            var city = await context.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                throw HttpException.NotFoundException("Not Found");
            }
            var cityDto = mapper.Map<CityDto>(city);
            return cityDto;
        }
    }
}
