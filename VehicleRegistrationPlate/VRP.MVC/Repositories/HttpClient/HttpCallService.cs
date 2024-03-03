using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
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

        public async Task<T> PostData<T, TRequest>(string endPoint, TRequest request)
        {
            T data = default(T);

            var url = ApiUrl.Url + endPoint;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            var httpClient = httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }else
            {
                Debug.WriteLine("Failure");
            }
            return data;
        }

        public async Task<T> PutData<T, TRequest>(string endPoint, TRequest request)
        {
            T data = default(T);

            var url = ApiUrl.Url + endPoint;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

            var httpClient = httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }
            else
            {
                Debug.WriteLine("Failure");
            }
            return data;
        }
    }
}
