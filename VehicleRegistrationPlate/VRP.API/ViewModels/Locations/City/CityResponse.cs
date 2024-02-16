using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.City
{
    public class CityResponse : BasePagingResponse
    {
        public List<CityDto> Cities { get; set; }
    }
}
