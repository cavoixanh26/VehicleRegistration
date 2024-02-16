using VRP.API.ViewModels.Locations.District;

namespace VRP.API.Repositories.IServices.Locations
{
    public interface IDistrictService
    {
        Task<DistrictResponse> GetDistricts(DistrictRequest request);
        Task<DistrictDto> GetDistrictById(int id);
    }
}
