using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Procedures
{
    public class ProcedureResponse : BasePagingResponse
    {
        public List<ProcedureDto> Procedures { get; set; }
    }
}
