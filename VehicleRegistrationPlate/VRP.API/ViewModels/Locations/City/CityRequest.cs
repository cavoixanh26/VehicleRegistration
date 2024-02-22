using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.City
{
    public class CityRequest : BasePagingRequest
    {
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
    }
}
