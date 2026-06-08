using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class TypeReaction
{
    public int ReactionId { get; set; }

    public string ReactionDescription { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
