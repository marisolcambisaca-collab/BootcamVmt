using Insta.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Insta.Application.Models.Requests.User
{
    public class UpdateUserRequest
    {
        [MaxLength(50, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(3, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string? NameUser { get; set; }

        [EmailAddress(ErrorMessage = ValidationConstants.EMAIL_ADDRESS)]
        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        public string? Email { get; set; }
        public Guid? TypeUserId { get; set; }
        public bool? Visibility { get; set; }
    }
}