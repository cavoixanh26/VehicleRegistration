using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Locations.Districts
{
    public class DistrictRequest : BasePagingRequest
    {
        public int? CityId { get; set; }
    }
}
