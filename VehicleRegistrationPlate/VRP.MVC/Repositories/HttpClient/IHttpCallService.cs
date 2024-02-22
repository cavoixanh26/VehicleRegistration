using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Repositories.HttpClient
{
    public interface IHttpCallService
    {
        Task<T> GetData<T>(string endPoint, BasePagingRequest request);
    }
}
