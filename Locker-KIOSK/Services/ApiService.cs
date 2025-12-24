using Locker_KIOSK.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Locker_KIOSK.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
      
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<User>> UserExistsAsync(string userId)
        {
            var result = await GetAsync<User>(
                $"user/exists/{userId}");

            return result;
        }
        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            var result = new ApiResponse<T>();

            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    result.Success = false;
                    result.Message = $"HTTP Error: {response.StatusCode}";
                    return result;
                }

                var serverResponse =
                    await response.Content.ReadFromJsonAsync<ApiResponse<T>>();

                if (serverResponse.Data != null)
                {
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Message = "Success",
                        Data = serverResponse.Data
                    };
                }

                return new ApiResponse<T>
                {
                    Success = false,
                    Message = serverResponse?.Message ?? "No data returned"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest payload)
        {
            var result = new ApiResponse<TResponse>();

            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, payload);

                if (!response.IsSuccessStatusCode)
                {
                    result.Success = false;
                    result.Message = $"HTTP Error: {response.StatusCode}";
                    return result;
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();

                if (apiResponse != null)
                    return apiResponse;

                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Message = "No response data"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }


    }
}
