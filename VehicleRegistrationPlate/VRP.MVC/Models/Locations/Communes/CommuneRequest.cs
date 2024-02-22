using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Locations.Communes
{
    public class CommuneRequest : BasePagingRequest
    {
        public int? DistrictId { get; set; }
    }
}
