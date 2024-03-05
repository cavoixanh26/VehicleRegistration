using VRP.MVC.Models.Procedures.VehicleInformations;

namespace VRP.MVC.Models.Procedures
{
    public class RequestedProcedure
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int TypeOfRegistration { get; set; }
        public string TypeOfRegistrationName { get; set; }
        public int StatusProcudure { get; set; }
        public string StatusProcedureName { get; set; }
        public UserInformationProcedure? UserInformationProcedure { get; set; }
        public VehicleInformation? VehicleInformationProcedure { get; set; }
    }


    public class UserInformationProcedure
    {
        public string FirstName { get; set; }
        public string? MidlleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int CommuneId { get; set; }
        public string CommuneName { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string CitizenId { get; set; }
        public DateTime CitizenIssuanceDate { get; set; }
        public string CitizenIssuanceLocation { get; set; }
        public int ProcedureId { get; set; }
    }
}
