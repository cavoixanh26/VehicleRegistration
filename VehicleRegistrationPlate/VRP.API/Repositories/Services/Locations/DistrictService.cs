using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VRP.API.Extensions;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.District;

namespace VRP.API.Repositories.Services.Locations
{
    public class DistrictService : IDistrictService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;

        public DistrictService(
            ApplicationDbcontext context, 
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DistrictDto> GetDistrictById(int id)
        {
            var district = await context.Districts.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
            if (district == null)
                throw HttpException.NotFoundException("Not found");
            return mapper.Map<DistrictDto>(district);
        }

        public async Task<DistrictResponse> GetDistricts(DistrictRequest request)
        {
            var districts = await context.Districts
                .Where(x => (string.IsNullOrEmpty(request.KeyWords)
                        || x.Name.Contains(request.KeyWords))
                        && (!request.CityId.HasValue || x.CityId == request.CityId))
                .Include(x => x.City)
                .ToListAsync();

            var districtDtos = mapper.Map<List<DistrictDto>>(districts.Paginate(request));
            return new DistrictResponse
            {
                Districts = districtDtos,
                Page = request.GetPagingResponse(districts.Count)
            };
        }
    }
}
