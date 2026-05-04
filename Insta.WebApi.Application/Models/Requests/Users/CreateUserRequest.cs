using Insta.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Insta.Application.Models.Requests.User
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(3, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string NameUser { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [EmailAddress(ErrorMessage = ValidationConstants.EMAIL_ADDRESS)]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(8, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public Guid TypeUserId { get; set; }

        public bool Visibility { get; set; } = true;
    }
}
