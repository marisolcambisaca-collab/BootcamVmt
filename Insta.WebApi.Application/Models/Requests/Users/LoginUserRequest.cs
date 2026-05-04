using Insta.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Insta.Application.Models.Requests.Users
{
    public class LoginUserRequest
    {

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(3, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string NameUser { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(8, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string Password { get; set; } = null!;

    }
}
