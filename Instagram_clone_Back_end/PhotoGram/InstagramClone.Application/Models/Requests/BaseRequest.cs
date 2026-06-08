namespace InstagramClone.Application.Models.Requests
{
    public class BaseRequest
    {
        public int limit { get; set; } = 100;
        public int offset { get; set; } = 0;
    }
}
