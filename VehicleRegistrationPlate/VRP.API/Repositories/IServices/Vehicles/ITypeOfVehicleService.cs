using VRP.API.ViewModels.Vehicles;

namespace VRP.API.Repositories.IServices.Vehicles
{
    public interface ITypeOfVehicleService
    {
        List<TypeOfVehicleDto> GetTypeVehicles();
        TypeOfVehicleDto GetTypeVehicleDetail(int id);
    }
}
