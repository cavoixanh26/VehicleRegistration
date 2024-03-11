using VRP.API.Models.Procedure;

namespace VRP.API.ViewModels.Procedures.NumberRotatorLicensePlate
{
    public class InformationLicensePlate
    {
        public int ProcedureId { get; set; }
        public StatusProcudureEnum StatusProcudure { get; set; }
        public int CityId { get; set; }
        public string CityNumberIdentify { get; set; }
        public int DistrictId { get; set; }
        public string DistrictNumberIdentify { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
