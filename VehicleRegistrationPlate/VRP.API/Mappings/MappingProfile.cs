using AutoMapper;
using VRP.API.Models.Address;
using VRP.API.ViewModels.Locations.City;

namespace VRP.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
