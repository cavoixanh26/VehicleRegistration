using VRP.API.Models.Address;

namespace VRP.API.ViewModels.Locations.District
{
    public class DistrictDto : BaseAddress
    {
        public int? CityId { get; set; }
        public string? NameCity { get; set; }
    }
}
