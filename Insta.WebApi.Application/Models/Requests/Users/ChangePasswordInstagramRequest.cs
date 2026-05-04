using Insta.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Insta.Application.Models.Requests.User
{
    public class ChangePasswordInstagramRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string CurrentPassword { get; set; } = null!;


        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MinLength(15, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        public string NewPassword { get; set; } = null!;
    }
}
