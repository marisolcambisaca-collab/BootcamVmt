namespace Insta.Application.Models.Requests.User
{
    public class FilterUserRequest
    {
        public string? NameUser { get; set; }
        public string? Email { get; set; }

        public Guid? TypeUserId { get; set; }
        public bool? Visibility { get; set; }

        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 15; // carga de 15 en 15
    }
}
