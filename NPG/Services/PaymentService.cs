using NPG.Contracts;
using NPG.Models;
using System.Text.Json;
using System.Text;
using NPG.QueryTransaction;
using NPG.Tokens;
using NPG.Models.ResponsePayloads;
using NPG.Models.Request;
using System.Net.Http;

namespace NPG.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PaymentService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<Response<InvokePaymentResponse>> InvokePayment(InvokePaymentRequest request) 
        {

            string Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI2NmZmZDFkMC1lY2FkLTQyODMtYmNlYi1mMTg5YTJjZDVkOTYiLCJ0eXAiOiJhdCtqd3QiLCJNZXJjaGFudElkIjoiNDAwMTY4Nk1US0s0TTAxIiwiVGVybWluYWxJZCI6IjQwMDE2ODU1MDc4IiwiZXhwIjoxNzEwMjQ4NjM4LCJpc3MiOiJodHRwczovL3Rlc3RwYXkubXRuLm5nIiwiYXVkIjoiaHR0cHM6Ly90ZXN0cGF5Lm10bi5uZyJ9.jtCFBgYgABTv_W4ZXoA6pU0RbYCr1_SiDaiBUe2oLc0lhGasWHcJKjsmH_lKC-Q7LgucIumbUiNkwyO1abqXTA";
            var paymentUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:InvokePayment")}";
            string requestStr = JsonSerializer.Serialize(request);
            var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

           // _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            var response = await _httpClient.PostAsync(new Uri(paymentUrl), jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Success Response Content: {responseContent}");
                var paymentResponse = JsonSerializer.Deserialize<InvokePaymentResponse>(responseContent);
                return Response<InvokePaymentResponse>.Success(paymentResponse);
            }
            else
            {
                // Capture and log the error details
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Success Response Content: {errorContent}");
                Console.WriteLine($"Error Content: {errorContent}");

                return Response<InvokePaymentResponse>.Failed($"Payment failed. Status code: {response.StatusCode}");
            }
        }
        public async Task<Response<InvokePaymentResponse>> DynamicSettlement(DynamicSettlementRequest request)
        {
            string Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI3MjU4YzhiNC1jYjRjLTRlOWEtYmVkMS1mMzE0ZWU5MjA3YTAiLCJ0eXAiOiJhdCtqd3QiLCJNZXJjaGFudElkIjoiNDAwMTY4Nk1US0s0TTAxIiwiVGVybWluYWxJZCI6IjQwMDE2ODU1MDc4IiwiZXhwIjoxNzEwMjY1MjUxLCJpc3MiOiJodHRwczovL3Rlc3RwYXkubXRuLm5nIiwiYXVkIjoiaHR0cHM6Ly90ZXN0cGF5Lm10bi5uZyJ9.ZFNfFzL3wNqV8nmyE9-ZDuulSwGd5IBjLkLH8A6iWoCWJiLkYgotAMR3wG-xbHVq5jMS-0I8q-AYZg2VbZS7rw";
            var paymentUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:InvokePayment")}";
            string requestStr = JsonSerializer.Serialize(request);
            var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            var response = await _httpClient.PostAsync(new Uri(paymentUrl), jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Success Response Content: {responseContent}");
                var paymentResponse = JsonSerializer.Deserialize<InvokePaymentResponse>(responseContent);
                return Response<InvokePaymentResponse>.Success(paymentResponse);
            }
            else
            {
                // Capture and log the error details
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Success Response Content: {errorContent}");
                Console.WriteLine($"Error Content: {errorContent}");

                return Response<InvokePaymentResponse>.Failed($"Payment failed. Status code: {response.StatusCode}");
            }
        }
       /* public async Task<Response<ProfileMerchantResponse>> ProfileMerchant(ProfileMerchantRequest request)
        {
            var profileMerchantUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:ProfileMerchant")}";
            string requestStr = JsonSerializer.Serialize(request);
            var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(profileMerchantUrl), jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var profileMerchantResponse = JsonSerializer.Deserialize<ProfileMerchantResponse>(responseContent);
                return Response<ProfileMerchantResponse>.Success(profileMerchantResponse);
            }
            else
            {
                return Response<ProfileMerchantResponse>.Failed($"Profile Merchant failed. Status code: {response.StatusCode}");
            }
        }
        public async Task<Response<TransactionQueryResponse>> TransactionQuery(TransactionQueryRequest request)
        {
            var queryUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:TransactionQuery")}";
            string requestStr = JsonSerializer.Serialize(request);
            var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(queryUrl), jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var queryResponse = JsonSerializer.Deserialize<TransactionQueryResponse>(responseContent);
                return Response<TransactionQueryResponse>.Success(queryResponse);
            }
            else
            {
                return Response<TransactionQueryResponse>.Failed($"Transaction query failed. Status code: {response.StatusCode}");
            }
        }

        public async Task<Response<GetTokensResponse>> GetTokens(GetTokensRequest request)
        {
            try
            {
                var tokensUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:GetTokens")}";
                string requestStr = JsonSerializer.Serialize(request);
                var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(new Uri(tokensUrl), jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var tokensResponse = JsonSerializer.Deserialize<GetTokensResponse>(responseContent);
                    return Response<GetTokensResponse>.Success(tokensResponse);
                }
                else
                {
                    return Response<GetTokensResponse>.Failed($"GetTokens failed. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Response<GetTokensResponse>.Failed("An error occurred while processing the request.");
            }
        }*/
        public async Task<Response<DeleteTokensResponse>> DeleteTokens(DeleteTokensRequest request)
        {
            try
            {
                var deleteTokensUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:DeleteTokens")}";
                string requestStr = JsonSerializer.Serialize(request);
                var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(new Uri(deleteTokensUrl), jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var deleteTokensResponse = JsonSerializer.Deserialize<DeleteTokensResponse>(responseContent);
                    return Response<DeleteTokensResponse>.Success(deleteTokensResponse);
                }
                else
                {
                    return Response<DeleteTokensResponse>.Failed($"DeleteTokens failed. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Response<DeleteTokensResponse>.Failed("An error occurred while processing the request.");
            }
        }/*
        public async Task<Response<GetChargeResponse>> GetCharge(GetChargeRequest request)
        {
            try
            {
                var chargeUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:GetCharge")}";
                string requestStr = JsonSerializer.Serialize(request);
                var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(new Uri(chargeUrl), jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var chargeResponse = JsonSerializer.Deserialize<GetChargeResponse>(responseContent);
                    return Response<GetChargeResponse>.Success(chargeResponse);
                }
                else
                {
                    return Response<GetChargeResponse>.Failed($"GetCharge failed. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Response<GetChargeResponse>.Failed("An error occurred while processing the request.");
            }
        }
        public async Task<Response<GetAccountDetailsResponse>> GetAccountDetails(GetAccountDetailsRequest request)
        {
            try
            {
                var accountDetailsUrl = $"{_configuration.GetValue<string>("ApiSettings:BaseUrl")}{_configuration.GetValue<string>("ApiSettings:GetAccountDetails")}";
                string requestStr = JsonSerializer.Serialize(request);
                var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(new Uri(accountDetailsUrl), jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var accountDetailsResponse = JsonSerializer.Deserialize<GetAccountDetailsResponse>(responseContent);
                    return Response<GetAccountDetailsResponse>.Success(accountDetailsResponse);
                }
                else
                {
                    return Response<GetAccountDetailsResponse>.Failed($"GetAccountDetails failed. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Response<GetAccountDetailsResponse>.Failed("An error occurred while processing the request.");
            }
        }*/
    }
}