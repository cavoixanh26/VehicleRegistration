namespace VRP.MVC.Models.Locations.Communes
{
    public class Commune : BaseAddress
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}
