using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerApi.Application.Models.Requests.TallerApi;

namespace Taller.WebApi.http.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class TallerController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]) CreateTallerApiRequest
        {
            return Ok("Usuario creado");
        }

        public async Task<IActionResult> Get()
        {
            return Ok("Usuario creado");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]) CreateTallerApiRequest
        {
            return Ok("Usuario creado ")
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok("Usuario id Eliminado ")
        }




    }
}
