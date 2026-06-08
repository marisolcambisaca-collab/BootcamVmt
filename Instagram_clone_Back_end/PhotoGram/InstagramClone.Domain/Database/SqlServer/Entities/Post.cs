using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class Post
{
    public Guid PostId { get; set; }

    public bool IsStory { get; set; }

    public Guid UserId { get; set; }

    public string PostDescription { get; set; } = null!;

    public string? LocationName { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string MediaUrl { get; set; } = null!;

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Hashtag> Hashtags { get; set; } = new List<Hashtag>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
