using Insta.Shared.Constants;
using Instagram.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Insta.Application.Models.Requests.Media

{
    public class CreateMediaRequest
    {

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int PostId { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string MediaUrl { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [EnumDataType(typeof(MediaType), ErrorMessage = "Solo se permite 'image' o 'video'")]
        public MediaType MediaType { get; set; }

    }

}


