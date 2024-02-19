using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Procedures
{
    public class ProcedureResponse : BasePagingResponse
    {
        public List<ProcedureDto> Procedures { get; set; }
    }
}
