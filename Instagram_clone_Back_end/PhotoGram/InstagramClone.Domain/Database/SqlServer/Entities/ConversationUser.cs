using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class ConversationUser
{
    public Guid ConversationId { get; set; }

    public Guid IdUser { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
