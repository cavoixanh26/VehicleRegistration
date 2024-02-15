using VRP.API.Models.Authentication;

namespace VRP.API.Models.InformationUser
{
    public class CitizenIdentifycation
    {
        public int Id { get; set; }
        public string CitizenId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string IssuanceLocation { get; set; }
        public Guid? UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
