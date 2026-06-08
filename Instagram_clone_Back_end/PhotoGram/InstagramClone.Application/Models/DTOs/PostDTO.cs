namespace InstagramClone.Application.Models.DTOs
{
    public class PostDTO
    {
        public Guid PostID { get; set; }
        public Boolean IsStory { get; set; }
        public Guid UserID { get; set; }
        public string PostDescription { get; set; }
        public string? LocationName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string MediaUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
