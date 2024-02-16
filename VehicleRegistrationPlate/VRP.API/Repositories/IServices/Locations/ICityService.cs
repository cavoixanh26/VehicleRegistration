using VRP.API.ViewModels.Locations.City;

namespace VRP.API.Repositories.IServices.Locations
{
    public interface ICityService
    {
        Task<CityResponse> GetCities(CityRequest request);
        Task<CityDto> GetCityById(int id);
    }
}
