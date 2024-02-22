using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Locations.Cities
{
    public class CityResponse : BasePagingResponse
    {
        public List<CityVM> Cities { get; set; }
    }
}
