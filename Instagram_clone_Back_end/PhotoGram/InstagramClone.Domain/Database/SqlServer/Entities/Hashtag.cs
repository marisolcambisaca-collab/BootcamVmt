using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class Hashtag
{
    public int HashtagId { get; set; }

    public string HashtagDescription { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
