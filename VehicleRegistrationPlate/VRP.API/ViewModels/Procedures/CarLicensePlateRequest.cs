namespace VRP.API.ViewModels.Procedures
{
    public class CarLicensePlateRequest
    {
        public UserInformationRequest  InformationUser{ get; set; }
        public CitizenIdentificationRequest CitizenIdentification { get; set; }
    }

    public class UserInformationRequest
    {
        public string FirstName { get; set; }
        public string? MidlleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int CommuneId { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

    public class CitizenIdentificationRequest
    {
        public string CitizenId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string IssuanceLocation { get; set; }
    }
}
