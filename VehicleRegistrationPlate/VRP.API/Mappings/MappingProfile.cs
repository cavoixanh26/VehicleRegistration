using AutoMapper;
using VRP.API.Models.Address;
using VRP.API.ViewModels.Locations.City;
using VRP.API.ViewModels.Locations.Commune;
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
            CreateMap<Commune, CommuneDto>()
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.District.City.Name))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.District.City.Id))
                .ReverseMap();
        }
    }
}
