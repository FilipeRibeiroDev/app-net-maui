using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BraboDevApp.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly Lazy<HttpClient> _httpClient = 
            new(() =>
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            });

        public async Task<TResult> PostAsync<TResult, TSend>(string uri, TSend data, string token = "")
        {
            var httpClient = GetOrCreateHttpClient(token);

            var body = new StringContent(JsonSerializer.Serialize(data));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync(uri, body).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default;

            var result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }

        private HttpClient GetOrCreateHttpClient(string token)
        {
            var httpClient = _httpClient.Value;
            httpClient.DefaultRequestHeaders.Clear();

            httpClient.DefaultRequestHeaders.Authorization =
                !string.IsNullOrEmpty(token) ?
                new System.Net.Http.Headers.AuthenticationHeaderValue(token) :
                null;

            return httpClient;
        }
    }
}
