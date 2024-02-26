using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Procedures
{
    public class ProcedureRequest : BasePagingRequest
    {
        public int? TypeOfRegistration { get; set; }
        public int? StatusProcedure { get; set; }
    }
}
