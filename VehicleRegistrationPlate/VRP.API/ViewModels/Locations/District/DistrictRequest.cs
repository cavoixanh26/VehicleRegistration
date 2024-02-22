using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.District
{
    public class DistrictRequest : BasePagingRequest
    {
        public int? CityId { get; set; }
        public int? CommuneId { get; set; }
    }
}
