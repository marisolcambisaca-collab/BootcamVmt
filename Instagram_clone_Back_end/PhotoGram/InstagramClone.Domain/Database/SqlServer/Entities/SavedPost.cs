using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class SavedPost
{
    public Guid IdUser { get; set; }

    public Guid PostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
