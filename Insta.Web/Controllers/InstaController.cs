


using Insta.Application.Models.Requests.Photos;
using Insta.Application.Interfaces.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class     InstaController(IInstaService  InstaService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromForm] PhotoRequest request)
        {
            InstaService.PublicarContenido(request);
            return Ok();
        }
    } 

}
