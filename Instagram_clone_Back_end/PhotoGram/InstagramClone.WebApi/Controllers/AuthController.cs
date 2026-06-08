using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Auth;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAuthRequest model)
        {
            var srv = await service.Login(model);
            return Ok(srv);
        }
    }
}
