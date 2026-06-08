namespace InstagramClone.Application.Models.Requests.Users
{
    public class GetUsersRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string? NameUser { get; set; }
    }
}
