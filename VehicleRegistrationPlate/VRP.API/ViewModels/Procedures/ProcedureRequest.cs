using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Procedures
{
    public class ProcedureRequest : BasePagingRequest
    {
        public int? TypeOfRegistration { get; set; }
        public int? StatusProcedure { get; set; }
    }
}
