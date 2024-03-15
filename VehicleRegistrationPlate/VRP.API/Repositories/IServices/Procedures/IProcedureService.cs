using VRP.API.Models.Authentication;
using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.HanldeRequest;
using VRP.API.ViewModels.Procedures.NumberRotatorLicensePlate;
using VRP.API.ViewModels.Procedures.VehicleInformationProcedures;

namespace VRP.API.Repositories.IServices.Procedures
{
    public interface IProcedureService
    {
        Task<CarLicensePlateResponse> CreateCarLicensePlate(CarLicensePlateRequest request, Guid userId);
        Task<RequestedProcedure> UpdateVehicleInformation(int procedureId, VehicleRequest request, AppUser currentUser);
        Task<ProcedureResponse> GetProcedures(ProcedureRequest request, AppUser currentUser);
        Task<RequestedProcedure> GetUserInformationProcedureById(int id, AppUser currentUser);
        Task<ProcedureDto> ApproveRequestedProcedure(ApproveRequestedProcedure request);
        Task<ProcedureDto> RejectRequestProcedure(RejectRequestedProcedure request);

        Task<InformationLicensePlate> GetInformationUserInRotatorProcess(int procedureId, AppUser currentUser);
        Task<VehicleInformationProcedure> UpdateNumberLicensePlate(UpdateNumberLicensePlateRequest request, AppUser? currentUser);

        Task CancelProcedure(int procedureId, AppUser currentUser);
    }
}
