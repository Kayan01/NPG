using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NPG.Contracts;
using NPG.Models;
using NPG.Models.Request;
using NPG.Models.ResponsePayloads;
using NPG.QueryTransaction;
using NPG.Tokens;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace NPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IAuthService _authService; 
        private readonly IPaymentService _paymentService;
        private readonly HttpClient _httpClient;
        public PaymentController(IAuthService authService, IPaymentService paymentService, HttpClient httpClientFactory)
        {
            _authService = authService;
           _paymentService = paymentService;
           _httpClient = httpClientFactory;
        }
/*
        [HttpPost("invoke-payment")]
        public async Task<IActionResult> InvokePayment([FromBody] InvokePaymentRequest request)
        {
            try
            {
                // Assuming you need authentication before invoking payment
                //var authResponse = await _authService.Authenticate(request);

                //if (!authResponse.IsSuccess)
                //{
                //    return BadRequest(authResponse.ErrorMessage);
                //}


                var paymentResponse = await _paymentService.InvokePayment(request);

                if (paymentResponse.IsSuccess)
                {
                    return Ok(paymentResponse.Data);
                }
                else
                {
                    return BadRequest(paymentResponse.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }*/

        [HttpPost("[action]")]
        public async Task<IActionResult> InvokePayment([FromBody] InvokePaymentRequest request)
        {
            try
            {
                string Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhMTY0MWFkYS0xODNjLTRjNDMtODY3Zi03ZTEzMzk3MjRlNTUiLCJ0eXAiOiJhdCtqd3QiLCJNZXJjaGFudElkIjoiNDAwMTY4Nk1US0s0TTAxIiwiVGVybWluYWxJZCI6IjQwMDE2ODU1MDc4IiwiZXhwIjoxNzEwMjc0OTE1LCJpc3MiOiJodHRwczovL3Rlc3RwYXkubXRuLm5nIiwiYXVkIjoiaHR0cHM6Ly90ZXN0cGF5Lm10bi5uZyJ9.ZIi66UKeHPrKw1Oyh7ULV7tr26WsMATigcrS8uCjNJLCkKIdHQ-KGtlFWssI8c7qOV_aWGZTU1_d5M3Vawhq9w";
               
                var reqMessage = new HttpRequestMessage(HttpMethod.Post, "https://testpay.mtn.ng/gateway/api/InvokePayment");
                string requestStr = JsonSerializer.Serialize(request);
                var jsonContent = new StringContent(requestStr, Encoding.UTF8, "application/json");
                reqMessage.Content = jsonContent;
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                // _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                var response = await _httpClient.SendAsync(reqMessage);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Success Response Content: {responseContent}");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    var paymentResponse = JsonSerializer.Deserialize<InvokePaymentResponse>(responseContent, options);
                    return Ok(Response<InvokePaymentResponse>.Success(paymentResponse));
                }
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[HttpPost("dynamic-settlemt")]
        //public async Task<IActionResult> DynamicSettlement([FromBody] DynamicSettlementRequest request)
        //{
        //    try
        //    {
        //        // Assuming you need authentication before invoking payment
        //        //var authResponse = await _authService.Authenticate(request);

        //        //if (!authResponse.IsSuccess)
        //        //{
        //        //    return BadRequest(authResponse.ErrorMessage);
        //        //}

        //        var paymentResponse = await _paymentService.DynamicSettlement(request);

        //        if (paymentResponse.IsSuccess)
        //        {
        //            return Ok(paymentResponse.Data);
        //        }
        //        else
        //        {
        //            return BadRequest(paymentResponse.ErrorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        return StatusCode(500, "Internal Server Error");
        //    }
        /* 
         [HttpPost("profile-merchant")]
         public async Task<IActionResult> ProfileMerchant([FromBody] ProfileMerchantRequest request)
         {
             try
             {
                 //// Assuming you need authentication before profiling merchant
                 //var authResponse = await _authService.Authenticate(request.AuthRequest);

                 //if (!authResponse.IsSuccess)
                 //{
                 //    return BadRequest(authResponse.ErrorMessage);
                 //}

                 var profileMerchantResponse = await _paymentService.ProfileMerchant(request);

                 if (profileMerchantResponse.IsSuccess)
                 {
                     return Ok(profileMerchantResponse.Data);
                 }
                 else
                 {
                     return BadRequest(profileMerchantResponse.ErrorMessage);
                 }
             }
             catch (Exception ex)
             {
                 // Log the exception
                 return StatusCode(500, "Internal Server Error");
             }
         }*/
        //[HttpPost("transaction-query")]
        //public async Task<IActionResult> TransactionQuery([FromBody] TransactionQueryRequest request)
        //{
        //    try
        //    {
        //        var queryResponse = await _paymentService.TransactionQuery(request);

        //        if (queryResponse.IsSuccess)
        //        {
        //            return Ok(queryResponse.Data);
        //        }
        //        else
        //        {
        //            return BadRequest(queryResponse.ErrorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log the exception
        //        return StatusCode(500, "Internal Server Error");
        //    }
        // }
        /*[HttpPost("GetTokens")]
        public async Task<IActionResult> GetTokens([FromBody] GetTokensRequest request)
        {
            try
            {
                var tokensResponse = await _paymentService.GetTokens(request);

                if (tokensResponse.IsSuccess)
                {
                    return Ok(tokensResponse.Data);
                }
                else
                {
                    return BadRequest(tokensResponse.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }*/
        //[HttpPost("DeleteTokens")]
        //public async Task<IActionResult> DeleteTokens([FromBody] DeleteTokensRequest request)
        //{
        //    try
        //    {
        //        var deleteTokensResponse = await _paymentService.DeleteTokens(request);

        //        if (deleteTokensResponse.IsSuccess)
        //        {
        //            return Ok(deleteTokensResponse.Data);
        //        }
        //        else
        //        {
        //            return BadRequest(deleteTokensResponse.ErrorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log the exception
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        /* [HttpPost("get-charge")]
         public async Task<IActionResult> GetCharge([FromBody] GetChargeRequest request)
         {
             try
             {
                 var chargeResponse = await _paymentService.GetCharge(request);

                 if (chargeResponse.IsSuccess)
                 {
                     return Ok(chargeResponse.Data);
                 }
                 else
                 {
                     return BadRequest(chargeResponse.ErrorMessage);
                 }
             }
             catch (Exception ex)
             {
                 // Log the exception
                 return StatusCode(500, "Internal Server Error");
             }
         }*/
        /*[HttpPost("get-account-details")]
        public async Task<IActionResult> GetAccountDetails([FromBody] GetAccountDetailsRequest request)
        {
            try
            {
                // Assuming you need authentication before getting account details
                // var authResponse = await _authService.Authenticate(request);

                // if (!authResponse.IsSuccess)
                // {
                //     return BadRequest(authResponse.ErrorMessage);
                // }

                var accountDetailsResponse = await _paymentService.GetAccountDetails(request);

                if (accountDetailsResponse.IsSuccess)
                {
                    return Ok(accountDetailsResponse.Data);
                }
                else
                {
                    return BadRequest(accountDetailsResponse.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }*/

    }
}