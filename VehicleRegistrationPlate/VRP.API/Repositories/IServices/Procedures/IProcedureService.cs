using VRP.API.ViewModels.Procedures;

namespace VRP.API.Repositories.IServices.Procedures
{
    public interface IProcedureService
    {
        Task<CarLicensePlateResponse> CreateCarLicensePlate(CarLicensePlateRequest request, Guid userId);
    }
}
