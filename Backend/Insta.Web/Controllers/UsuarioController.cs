using Insta.Application.Interfaces.Services;
using Insta.Application.Models.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest model)
        {
            var result = await userService.Create(model);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await userService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterUserRequest model)
        {
            var result = userService.Get(model);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest model)
        {
            var result = await userService.Update(id, model);
            return Ok(result);
        }

        [HttpPatch("{id:guid}/password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordInstagramRequest model)
        {
            var result = await userService.ChangePassword(id, model);
            return Ok(result);
        }
    }
}