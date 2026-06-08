using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Users;
using InstagramClone.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController(IUserService service) : ControllerBase
    {
        [HttpPost]//cualquiera puede crear un usuario
        public async Task<IActionResult> Create([FromBody] CreateUserRequest Model)
        {
            var srv = await service.Create(Model);//srv = srv
            return Ok(srv);
        }

        [HttpGet]//el buscador usara este metodo pero solo los usuarios autorizados
        [Authorize(Roles = $"{ConfigurationConstants.AUTHORIZE_REGULAR},{ConfigurationConstants.AUTHORIZE_ADMINISTRATOR},{ConfigurationConstants.AUTHORIZE_CONSTANT_CREATOR},{ConfigurationConstants.AUTHORIZE_BUSINESS_ACCOUNT}")]
        public async Task<IActionResult> GetUser([FromQuery] GetUsersRequest request)
        {
            var srv = await service.GetUser(request);
            return Ok(srv);
        }

        [HttpGet("{id:guid}")]//este metodo es solo para administradores
        [Authorize(Roles = $"{ConfigurationConstants.AUTHORIZE_ADMINISTRATOR}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var srv = await service.GetUserById(id);
            return Ok(srv);
        }
    }
}
