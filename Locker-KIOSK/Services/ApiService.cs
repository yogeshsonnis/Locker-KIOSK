using System.Net.Http;
using System.Net.Http.Json;

namespace Locker_KIOSK.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        private readonly string? apiKey;
        private readonly string? baseUrl;
        private readonly string? version;


        public ApiService()
        {
            apiKey = AppConfig.Configuration["ApiSettings:Apikey"];
            baseUrl = AppConfig.Configuration["ApiSettings:BaseUrl"];
            version = AppConfig.Configuration["ApiSettings:Version"];

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<T?> UserExistsAsync<T>(String userId) where T : class
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }
            try
            {
                var response = await _httpClient.GetAsync($"/api/{version}/Locker/user/exists/{userId}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                //   var json = await response.Content.ReadAsStringAsync();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


    }
}
