using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.Commune
{
    public class CommuneRequest : BasePagingRequest
    {
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
    }
}
