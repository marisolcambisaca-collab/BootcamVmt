using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Posts;
using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Interfaces.Services
{
    public interface IPostService
    {
        public Task<GenericResponse<PostDTO>> PostCreate(CreatePostRequest model, Guid id);
    }
}
