using VRP.API.Models.Procedure;

namespace VRP.API.Models.InformationUser
{
    public class CitizenIdentificationRequestInProcedure
    {
        public int Id { get; set; }
        public string CitizenId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string IssuanceLocation { get; set; }
        public int? ProcedureId { get; set; }
        public virtual RegistrationProcedure? Procedure { get; set; }
    }
}
