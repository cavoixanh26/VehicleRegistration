using AutoMapper;
using VRP.API.Models.Address;
using VRP.API.Models.InformationUser;
using VRP.API.Models.Procedure;
using VRP.API.Models.Vehicle;
using VRP.API.ViewModels.Locations.City;
using VRP.API.ViewModels.Locations.Commune;
using VRP.API.ViewModels.Locations.District;
using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.VehicleInformationProcedures;
using VRP.API.ViewModels.Vehicles;

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

            CreateMap<UserInformationRequest, InformationUserRequestInProcedure>()
                .ReverseMap();
            CreateMap<CitizenIdentificationRequest, CitizenIdentifycation>().ReverseMap();
            CreateMap<CitizenIdentificationRequest, CitizenIdentificationRequestInProcedure>().ReverseMap();
            CreateMap<RegistrationProcedure, ProcedureDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();

            CreateMap<InformationUserRequestInProcedure, UserInformationProcedure>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.CommuneName, opt => opt.MapFrom(src => src.Commune.Name))
                .ReverseMap();

            CreateMap<RegistrationProcedure, RequestedProcedure>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();

            CreateMap<TypeOfVehicle, TypeOfVehicleDto>()
                .ReverseMap();
            CreateMap<TypeOfVehicle, VehicleInformationProcedure>();
            CreateMap<VehicleRegistration, VehicleInformationProcedure>()
                .ForMember(dest => dest.TypeOfVehicle, opt => opt.MapFrom(src => src.TypeOfVehicle.Name));
            CreateMap<VehicleRegistration, VehicleRequest>()
                .ReverseMap();
        }
    }
}

