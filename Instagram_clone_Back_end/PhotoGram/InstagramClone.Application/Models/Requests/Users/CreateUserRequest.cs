using InstagramClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Application.Models.Requests.Users
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(5, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string NameUser { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [EmailAddress(ErrorMessage = ValidationConstants.EMAIL_ADDRESS)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [Compare("Password", ErrorMessage = ValidationConstants.PASSWORDS_MUST_MATCH)]
        public string RewritePassword { get; set; } = null!;
        public string TypeUser { get; set; } = "REGULAR"; // hay 4 tipos de usuario: REGULAR, CONTENT_CREATOR, PREMIUM, ADMINISTRATOR 
        public bool Visibility { get; set; } = true;

    }
}
