using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class Following
{
    public Guid FollowerId { get; set; }

    public Guid FollowingId { get; set; }

    public string StatusFollow { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Follower { get; set; } = null!;

    public virtual User FollowingNavigation { get; set; } = null!;
}
