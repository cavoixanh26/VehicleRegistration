using VRP.API.Models.Procedure;
using VRP.API.ViewModels.Procedures.VehicleInformationProcedures;

namespace VRP.API.ViewModels.Procedures
{
    public class RequestedProcedure
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int TypeOfRegistration { get; set; }
        public string TypeOfRegistrationName 
        { 
            get 
            {
                return Enum.GetName(typeof(TypeOfRegistrationLicencePlateEnum), TypeOfRegistration);
            }
            set { } 
        }
        public int StatusProcudure { get; set; }
        public string StatusProcedureName 
        {
            get 
            {
                return Enum.GetName(typeof(StatusProcudureEnum), StatusProcudure);
            }
            set{} 
        }

        public UserInformationProcedure? UserInformationProcedure { get; set; }
        public VehicleInformationProcedure? VehicleInformationProcedure { get; set; }
    }
}
