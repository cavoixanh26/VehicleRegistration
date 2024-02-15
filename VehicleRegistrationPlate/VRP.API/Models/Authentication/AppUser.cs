using Microsoft.AspNetCore.Identity;
using VRP.API.Models.Address;

namespace VRP.API.Models.Authentication
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Street { get; set; }
        public int? CommuneId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public virtual Commune? Commune { get; set; }
        public virtual District? District { get; set; }
        public virtual City? City { get; set; }
    }
}
