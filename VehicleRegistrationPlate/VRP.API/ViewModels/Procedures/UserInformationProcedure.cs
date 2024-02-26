namespace VRP.API.ViewModels.Procedures
{
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
    }
}
