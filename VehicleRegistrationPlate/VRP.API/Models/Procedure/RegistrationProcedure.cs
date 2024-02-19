using VRP.API.Models.Authentication;
using VRP.API.Models.Vehicle;

namespace VRP.API.Models.Procedure
{
    public class RegistrationProcedure
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Guid? UserId { get; set; }
        public TypeOfRegistrationLicencePlateEnum TypeOfRegistration { get; set; }
        public StatusProcudureEnum StatusProcudure { get; set; }
        public virtual VehicleRegistration? Vehicle { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
