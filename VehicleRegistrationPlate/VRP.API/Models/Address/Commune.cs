namespace VRP.API.Models.Address
{
    public class Commune : BaseAddress
    {
        public int? DistrictId { get; set; }
        public virtual District? District { get; set; }
    }
}
