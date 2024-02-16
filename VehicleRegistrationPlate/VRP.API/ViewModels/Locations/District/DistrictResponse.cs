using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.District
{
    public class DistrictResponse : BasePagingResponse
    {
        public List<DistrictDto> Districts { get; set; }
    }
}
