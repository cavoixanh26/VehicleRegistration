using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Locations.Districts
{
    public class DistrictResponse : BasePagingResponse
    {
        public List<District> Districts { get; set; }
    }
}
