using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("{userId:guid}/[controller]")]
    [ApiController]
    public class PostsController(IPostService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Guid userId, [FromForm] CreatePostRequest Model)
        {
            var rsp = await service.PostCreate(Model, userId);

            return Ok(rsp);
        }
    }
}
