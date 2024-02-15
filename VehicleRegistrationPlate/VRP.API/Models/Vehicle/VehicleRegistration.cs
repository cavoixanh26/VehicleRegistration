namespace VRP.API.Models.Vehicle
{
    public class VehicleRegistration
    {
        public int Id { get; set; }
        public string EngineN0 { get; set; }
        public string ClassisN0 { get; set; }
        public string? CarBrand { get; set; }
        public string? Color { get; set; }
        public string? LicencePlate { get; set; }
        public int? TypeOfVehicleId { get; set; }
        public virtual TypeOfVehicle? TypeOfVehicle { get; set; }
    }
}
