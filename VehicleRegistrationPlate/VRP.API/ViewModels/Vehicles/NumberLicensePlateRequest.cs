using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Vehicles
{
    public class NumberLicensePlateRequest : BasePagingRequest
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
