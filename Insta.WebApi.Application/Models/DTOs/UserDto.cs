namespace Insta.Application.Models.DTOs
{
    public class UserDto
    {
        public Guid IdUser { get; set; }
        public string? NameUser { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; } = null!;
        public Guid TypeUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Visibility { get; set; }

    }
}
