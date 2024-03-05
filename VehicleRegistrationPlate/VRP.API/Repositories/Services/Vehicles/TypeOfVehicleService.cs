using AutoMapper;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Repositories.IServices.Vehicles;
using VRP.API.ViewModels.Vehicles;

namespace VRP.API.Repositories.Services.Vehicles
{
    public class TypeOfVehicleService : ITypeOfVehicleService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;

        public TypeOfVehicleService(
            ApplicationDbcontext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public TypeOfVehicleDto GetTypeVehicleDetail(int id)
        {
            var vehicle = context.TypeOfVehicles.Find(id);
            if (vehicle == null)
                throw HttpException.NotFoundException("Not found vehicle");
            var vehicleDto = mapper.Map<TypeOfVehicleDto>(vehicle);
            return vehicleDto;
        }

        public List<TypeOfVehicleDto> GetTypeVehicles()
        {
            var vehicles = context.TypeOfVehicles.ToList();
            var vehicleDtos = mapper.Map<List<TypeOfVehicleDto>>(vehicles);
            return vehicleDtos;
        }
    }
}
