using AutoMapper;
using VRP.API.Models.Address;
using VRP.API.ViewModels.Locations.City;
using VRP.API.ViewModels.Locations.District;

namespace VRP.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<District, DistrictDto>()
                .ForMember(dest => dest.NameCity, opt => opt.MapFrom(src => src.City.Name))
                .ReverseMap();
        }
    }
}
