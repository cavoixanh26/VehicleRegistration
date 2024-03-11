using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Models.Procedure;
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

        public async Task<List<string>> GetExistNumberLicensePlate(NumberLicensePlateRequest request)
        {
            var existVehicle = await context.InformationUserRequestInProcedures
                .Where(x => x.CityId == request.CityId && x.DistrictId == request.DistrictId
                && x.Procedure.StatusProcudure == StatusProcudureEnum.RotatedNumberLicensePlate)
                .Include(x => x.Procedure)
                .ThenInclude(x => x.Vehicle)
                .Select(x => x.Procedure.Vehicle.LicencePlate).ToListAsync();

            return existVehicle;
        }

        public TypeOfVehicleDto GetTypeVehicleDetail(int id)
        {
            var vehicle = context.TypeOfVehicles.Find(id);
            if (vehicle == null)
                throw HttpException.NotFoundException("Not found vehicle");
            var vehicleDto = mapper.Map<TypeOfVehicleDto>(vehicle);
            return vehicleDto;
        }

        public async Task<List<TypeOfVehicleDto>> GetTypeVehicles()
        {
            var vehicles = await context.TypeOfVehicles.ToListAsync();
            var vehicleDtos = mapper.Map<List<TypeOfVehicleDto>>(vehicles);
            return vehicleDtos;
        }
    }
}
