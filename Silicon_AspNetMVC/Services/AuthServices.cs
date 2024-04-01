using Newtonsoft.Json;
using Silicon_AspNetMVC.ViewModels.Auth;
using System.Text;

namespace Silicon_AspNetMVC.Services
{
    public class AuthServices(HttpClient httpClient, IConfiguration configuration)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;


        public async Task<string> GetAuthTokenAsync(SignInViewModel viewModel)
        {
            var content = new StringContent(JsonConvert.SerializeObject(viewModel.Form), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7091/api/Auth/token?key={_configuration["ApiKey:Secret"]}", content);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }

            return null!;
        }

        public async Task<string> GetAuthTokenForExternalUserAsync(string email)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { Email = email }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7091/api/Auth/external?key={_configuration["ApiKey:Secret"]}", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null!;
        }
    }
}

