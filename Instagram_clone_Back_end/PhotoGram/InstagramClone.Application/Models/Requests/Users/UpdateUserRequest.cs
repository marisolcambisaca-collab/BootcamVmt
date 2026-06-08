using InstagramClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Application.Models.Requests.Users
{
    public class UpdateUserRequest
    {
        [MaxLength(50, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(5, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string NameUser { get; set; } = null!;
        public string TypeUser { get; set; } = null!; // hay 4 tipos de usuario: REGULAR, CONTENT_CREATOR, PREMIUM, ADMINISTRATOR 
        public bool Visibility { get; set; } = false;
    }
}
