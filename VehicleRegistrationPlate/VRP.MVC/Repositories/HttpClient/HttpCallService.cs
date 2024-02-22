using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using VRP.MVC.Constrants;
using VRP.MVC.Models.BaseDtos;

namespace VRP.MVC.Repositories.HttpClient
{
    public class HttpCallService : IHttpCallService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpCallService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<T> GetData<T>(string endPoint, BasePagingRequest request = null)
        {
            T data = default(T);

            var url = ApiUrl.Url + endPoint;
            if (request != null)
            {
                var properties = request.GetType().GetProperties();
                var queryParams = properties.ToDictionary(p => p.Name, p => p.GetValue(request)?.ToString());
                
                if (queryParams.Any())
                {
                    url += "?" + string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
                }
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                    { HeaderNames.Accept, "application/json" },
                }
            };

            var httpClient = httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);   
            }else
            {
                Debug.WriteLine("Failure");
            }
            return data;
        }
    }
}
