using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRP.API.Extensions;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.ViewModels.Locations.Commune;

namespace VRP.API.Repositories.Services.Locations
{
    public class CommuneService : ICommuneService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;

        public CommuneService(
            ApplicationDbcontext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CommuneDto> GetCommuneById(int id)
        {
            var commune = await context.Communes.Include(x => x.District).FirstOrDefaultAsync(x => x.Id == id);
            if (commune == null)
            {
                throw HttpException.NotFoundException("Not found");
            }

            var communeDto = mapper.Map<CommuneDto>(commune);
            return communeDto;
        }

        public async Task<CommuneResponse> GetCommunes(CommuneRequest request)
        {
            var communes = await context.Communes
                .Where(x => string.IsNullOrEmpty(request.KeyWords)
                || x.Name.Contains(request.KeyWords)
                && (!request.CityId.HasValue || x.District.CityId == request.CityId)
                && (!request.DistrictId.HasValue || x.DistrictId == request.DistrictId))
                .Include(x => x.District)
                .ThenInclude(x => x.City)
                .ToListAsync();

            var communeDtos = mapper.Map<List<CommuneDto>>(communes.Paginate(request));
            return new CommuneResponse
            {
                Communes = communeDtos,
                Page = request.GetPagingResponse(communes.Count)
            };
        }
    }
}
