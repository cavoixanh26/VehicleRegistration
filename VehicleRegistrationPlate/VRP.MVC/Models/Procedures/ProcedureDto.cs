namespace VRP.MVC.Models.Procedures
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int TypeOfRegistration { get; set; }
        public string TypeOfRegistrationName { get; set; }
        public int StatusProcudure { get; set; }
        public string StatusProcedureName { get; set; }
    }
}
