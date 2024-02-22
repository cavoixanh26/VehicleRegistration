using System.ComponentModel.DataAnnotations;

namespace VRP.MVC.Models.Procedures
{
    public class CarLicensePlateRequest
    {
        public UserInformationRequest InformationUser { get; set; }
        public CitizenIdentificationRequest CitizenIdentification { get; set; }
    }

    public class UserInformationRequest
    {
        public string FirstName { get; set; }
        public string? MidlleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int CommuneId { get; set; }
        public string Street { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }

    public class CitizenIdentificationRequest
    {
        [Required]
        public string CitizenId { get; set; }
        [Required]
        public DateTime IssuanceDate { get; set; }
        [Required]
        public string IssuanceLocation { get; set; }
    }
}
