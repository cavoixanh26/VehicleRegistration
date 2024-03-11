using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Procedures.RotatorNumber
{
    public class NumberLicensePlateRequest : BasePagingRequest
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
