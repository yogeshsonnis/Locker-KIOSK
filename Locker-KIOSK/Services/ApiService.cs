using Locker_KIOSK.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Controls;

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
            var response = await _httpClient.GetAsync($"user/exists/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<User>
                {
                    Success = false,
                    Message = response.ReasonPhrase
                };
            }

            var result = await response.Content.ReadFromJsonAsync<UserResponse>();

            return new ApiResponse<User>
            {
                Success = true,
                Data = result?.Data,
                Message = response.ReasonPhrase
            };
        }

        public async Task<ApiResponse<CarrierValidateResponse>?> IsParcelValidAsync(Parcel parcel)
        {
            var response = await _httpClient.PostAsJsonAsync("parcel/validate", parcel);

            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<CarrierValidateResponse>
                {
                    Success = false,
                    Message = response.ReasonPhrase
                };
            }
            var result = await response.Content.ReadFromJsonAsync<CarrierValidateResponse>();
            return new ApiResponse<CarrierValidateResponse>
            {
                Success = true,
                Data = result,
                Message = response.ReasonPhrase
            };
        }


    }
}
