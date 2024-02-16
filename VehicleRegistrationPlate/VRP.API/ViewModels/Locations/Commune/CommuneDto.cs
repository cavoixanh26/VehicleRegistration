using VRP.API.Models.Address;

namespace VRP.API.ViewModels.Locations.Commune
{
    public class CommuneDto : BaseAddress
    {
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
    }
}
