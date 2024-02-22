using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Models.Locations.Communes
{
    public class CommuneResponse : BasePagingResponse
    {
        public List<Commune> Communes { get; set; }
    }
}
