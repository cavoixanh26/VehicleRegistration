using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.HanldeRequest;

namespace VRP.API.Repositories.IServices.Procedures
{
    public interface IProcedureService
    {
        Task<CarLicensePlateResponse> CreateCarLicensePlate(CarLicensePlateRequest request, Guid userId);
        Task<ProcedureResponse> GetProcedures(ProcedureRequest request);
        Task<RequestedProcedure> GetUserInformationProcedureById(int id);
        Task ApproveRequestedProcedure(ApproveRequestedProcedure request);
        Task RejectRequestProcedure(RejectRequestedProcedure request);

    }
}
