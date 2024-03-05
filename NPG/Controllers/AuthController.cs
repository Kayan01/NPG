/*using Microsoft.AspNetCore.Mvc;
using NPG.Contracts;
using NPG.Models;
using NPG.Models.Request;
using NPG.Services;
using System.Threading.Tasks;

namespace NPG.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest request)
        {
            try
            {
                var authResponse = await _authService.Authenticate(request);

                if (authResponse.IsSuccess)
                {
                    return Ok(authResponse.Data);
                }
                else
                {
                    return BadRequest(authResponse.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
*/