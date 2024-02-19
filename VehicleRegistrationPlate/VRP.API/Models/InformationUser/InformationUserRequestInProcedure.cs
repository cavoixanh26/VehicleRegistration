using VRP.API.Models.Procedure;

namespace VRP.API.Models.InformationUser
{
    public class InformationUserRequestInProcedure
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MidlleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int CommuneId { get; set; }
        public string? Street { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int ProcedureId { get; set; }
        public virtual RegistrationProcedure Procedure { get; set; }
    }
}
