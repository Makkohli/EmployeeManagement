
    using Blazored.LocalStorage;

    using EmployeeManagement.Models;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;


namespace EmployeeManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(UserLogin userLogin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", userLogin);

            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (result is null) return false;

            await _localStorage.SetItemAsync("authToken", result.Token);

            // Set token in request headers
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", result.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        private class TokenResponse
        {
            public string Token { get; set; } = string.Empty;
        }
    }
}
