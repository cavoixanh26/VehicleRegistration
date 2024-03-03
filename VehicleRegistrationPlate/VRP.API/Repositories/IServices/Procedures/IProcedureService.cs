using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.HanldeRequest;

namespace VRP.API.Repositories.IServices.Procedures
{
    public interface IProcedureService
    {
        Task<CarLicensePlateResponse> CreateCarLicensePlate(CarLicensePlateRequest request, Guid userId);
        Task<ProcedureResponse> GetProcedures(ProcedureRequest request);
        Task<RequestedProcedure> GetUserInformationProcedureById(int id);
        Task<ProcedureDto> ApproveRequestedProcedure(ApproveRequestedProcedure request);
        Task<ProcedureDto> RejectRequestProcedure(RejectRequestedProcedure request);

    }
}
