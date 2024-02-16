using VRP.API.ViewModels.Locations.Commune;

namespace VRP.API.Repositories.IServices.Locations
{
    public interface ICommuneService
    {
        Task<CommuneResponse> GetCommunes(CommuneRequest request);
        Task<CommuneDto> GetCommuneById(int id);

    }
}
