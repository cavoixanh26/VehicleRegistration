using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.ViewModels.Locations.Commune
{
    public class CommuneResponse : BasePagingResponse
    {
        public List<CommuneDto> Communes { get; set; }
    }
}
