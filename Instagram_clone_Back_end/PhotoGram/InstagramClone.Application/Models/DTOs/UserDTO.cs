namespace InstagramClone.Application.Models.DTOs
{
    public class UserDTO
    {
        public Guid IdUser { get; set; }
        public string NameUser { get; set; }
        public string NameUnUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Visibility { get; set; }
        public string TypeUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
