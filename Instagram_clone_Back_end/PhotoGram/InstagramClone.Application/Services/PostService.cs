using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Posts;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Exceptions;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Shared.Constants;
using InstagramClone.Shared.Helper;
using System.Text.RegularExpressions;

namespace InstagramClone.Application.Services
{
    public class PostService(IPostRepository repository, IUserRepository userRepo, IHashtagRepository hashtagRepo, IUnitOfWork uwu) : IPostService
    {
        //primero se hara por separado luego se unira asi que tomalo en cuenta, por ahora necesitamos ver su funcionamiento en mentions y en hashtags
        private static List<string> ExtractHashTags(string text)
        {

            var matches = Regex.Matches(text, @"(?<=#)\w+");

            return matches
                .Select(x => x.Value.ToLower())
                .Distinct()
                .ToList();
        }

        private static List<string> ExtractMentions(string text)
        {
            var matches = Regex.Matches(text, @"(?<=@)\w+");

            return matches
                .Select(x => x.Value.ToLower())
                .Distinct()
                .ToList();
        }

        public async Task<GenericResponse<PostDTO>> PostCreate(CreatePostRequest model, Guid id)
        {
            var verify = await userRepo.IfExist(id);
            if (!verify) throw new NotFoundException("Su usuario no es valido");//validacion usuario existe

            if (model.MediaUrl is null || model.MediaUrl.Length == 0) throw new BadRequestException("Su archivo no es valido");//validacion media existente

            var media = model.MediaUrl;
            //extensiones apropiadas
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".mp4" };


            //FileName es una propiedad de los tipo IFormFile y get extension obvio es un metodo de path que obtiene la extension jpg, png, etc
            var extension = Path.GetExtension(media.FileName);
            if (!allowedExtensions.Contains(extension)) throw new BadRequestException("su archivo no es valido");


            var fileName = $"{Guid.NewGuid()}{extension}";
            //generacion de la ruta  previa
            var folderPath = @$"{RoutesConstants.ROUTE_MEDIA_URL}";


            //generacion de ruta completa por combinacion
            var fullPath = Path.Combine(folderPath, fileName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            await media.CopyToAsync(stream);

            //generacion de nombre del archivo en base de datos
            var post = new Post
            {
                PostId = Guid.NewGuid(),
                UserId = id,
                IsStory = model.IsStory,
                PostDescription = model.PostDescription,
                LocationName = model.LocationName,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                MediaUrl = fileName,
                CreatedAt = DateTimeHelper.UtcNow(),
            };

            var tags = ExtractHashTags(model.PostDescription);

            foreach (var tag in tags)
            {
                //verificacion sobre existencia previa del hashtag
                var hashtag = await hashtagRepo.GetByDescription(tag);
                //si no existe en tabla lo guarda en la misma
                if (hashtag is null)
                {
                    hashtag = new Hashtag
                    {
                        HashtagDescription = tag,
                        CreatedAt = DateTimeHelper.UtcNow()
                    };
                    //guarda el hashtag
                    await hashtagRepo.Create(hashtag);
                }
                post.Hashtags.Add(hashtag); //esta linea genera la relacion en PostHashtag 
                //ya que PostHashtag es una tabla intermedia y requiere trato especial
            }
            var names = ExtractMentions(model.PostDescription);
            foreach (var name in names)
            {
                var user = await userRepo.GetUserUnName(name);
                if (user is not null)
                {
                    post.Users.Add(user);
                }

            }
            //mejor que un If ('*') - valida si necesita expiresAt
            post.ExpiresAt = model.IsStory ? DateTimeHelper.UtcNow().AddHours(24) : null;
            await repository.Create(post);
            //cambios guardados unitariamente
            await uwu.SaveChangesAsync();

            return ResponseHelper.Create(Map(post));
        }




        private static PostDTO Map(Post post)
        {
            return new PostDTO
            {
                PostID = post.PostId,
                UserID = post.UserId,
                IsStory = post.IsStory,
                PostDescription = post.PostDescription,
                LocationName = post.LocationName,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                MediaUrl = post.MediaUrl,
                CreatedAt = post.CreatedAt,
                ExpiresAt = post.ExpiresAt
            };
        }
    }
}
