using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class Like
{
    public Guid UserId { get; set; }

    public int ReactionId { get; set; }

    public Guid PostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual TypeReaction Reaction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
