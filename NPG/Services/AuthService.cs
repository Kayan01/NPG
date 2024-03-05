using NPG.Models;
using System.Text.Json;
using System.Text;
using NPG.Contracts;
using NPG.Models.ResponsePayloads;
using NPG.Models.Request;

namespace NPG.Services
{
    public class AuthService : IAuthService
    {
       /*// private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        //private readonly IAuthService _authService;

        public AuthService(HttpClient httpClient, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            //  _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
           // _authService = authService;
        }

        public async Task<Response<AuthResponse>> Authenticate(AuthRequest request)
        {
            
            string validationResponse = ValidateRequest(request);
            if (!string.IsNullOrEmpty(validationResponse))
            {
                return Response<AuthResponse>.Failed(validationResponse);
            }

            var authUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:AuthEndpoint")}";
            string requestStr = JsonSerializer.Serialize(request);
            var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");
           // var response = await _httpClient.PostAsync(authUrl, jsonContent);
            var response = await _httpClient.PostAsync(new Uri(authUrl), jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent);
                return Response<AuthResponse>.Success(authResponse);
            }
            else
            {
                return Response<AuthResponse>.Failed($"Authentication failed. Status code: {response.StatusCode}");
            }
        }

        private string ValidateRequest(AuthRequest requestDto)
        {
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(requestDto.Password) || string.IsNullOrWhiteSpace(requestDto.Username)
                || string.IsNullOrWhiteSpace(requestDto.TerminalId))
            {
                errorMessage = $"Incomplete or empty request";
            }
            return errorMessage;
        }*/
    }
}
