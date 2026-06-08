using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class User
{
    public Guid IdUser { get; set; }

    public string NameUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid TypeUserId { get; set; }

    public bool Visibility { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string UserUnName { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ConversationUser> ConversationUsers { get; set; } = new List<ConversationUser>();

    public virtual ICollection<Following> FollowingFollowers { get; set; } = new List<Following>();

    public virtual ICollection<Following> FollowingFollowingNavigations { get; set; } = new List<Following>();

    public virtual ICollection<LetterMessage> LetterMessages { get; set; } = new List<LetterMessage>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

    public virtual TypeUser TypeUser { get; set; } = null!;

    public virtual ICollection<Post> PostsNavigation { get; set; } = new List<Post>();
}
