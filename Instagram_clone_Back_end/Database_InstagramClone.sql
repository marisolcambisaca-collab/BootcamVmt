USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'InstagramClone')
    CREATE DATABASE InstagramClone;
GO

USE InstagramClone;
GO

-- ============================================================
--  TABLA: TypeUsers  -COMPLETADO
-- ============================================================

CREATE TABLE TypeUsers(
	IdTypeUser				UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	NameType				NVARCHAR(50)		NOT NULL,
	StatisticsProActive		BIT					NOT NULL DEFAULT 0,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,
	CONSTRAINT PK_TypeUser PRIMARY KEY (IdTypeUser)
);
GO

-- ============================================================
--  TABLA: TypeReactions
-- ============================================================

CREATE TABLE TypeReactions(
	ReactionId				INT IDENTITY(1,1)	NOT NULL,
	ReactionDescription		NVARCHAR(50)		NOT NULL,
	CreatedAt				DATETIME2			NOT NULL  DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Reactions PRIMARY KEY (ReactionId),
	CONSTRAINT UQ_ReactionDescription UNIQUE (ReactionDescription)
);
GO

-- ============================================================
--  TABLA: Hashtags -COMPLETADO
-- ============================================================

CREATE TABLE Hashtags(
	HashtagId				INT IDENTITY(1,1)	NOT NULL,
	HashtagDescription		NVARCHAR(150)		NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Hashtags PRIMARY KEY (HashtagId),

	CONSTRAINT UQ_HashtagDescription UNIQUE (HashtagDescription)
);
GO

-- ============================================================
--  TABLA: Users -Completado
-- ============================================================

CREATE TABLE Users(
	IdUser					UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	NameUser				NVARCHAR(50)		NOT NULL,
	Email					NVARCHAR(100)		NOT NULL,
	Password				NVARCHAR(200)		NOT NULL,
	TypeUserId				UNIQUEIDENTIFIER	NOT NULL,				
	Visibility				BIT					NOT NULL DEFAULT 1,-- 1: Publico || 0:Privado
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Users PRIMARY KEY (IdUser),
	CONSTRAINT UQ_NameUser UNIQUE (NameUser),
	CONSTRAINT UQ_Email UNIQUE (Email),
	CONSTRAINT FK_Users_TypeUsers FOREIGN KEY (TypeUserId)
		REFERENCES TypeUsers(IdTypeUser)
);
GO

-- ============================================================
--  TABLA: Followings
-- ============================================================

CREATE TABLE Followings(
	FollowerId				UNIQUEIDENTIFIER	NOT NULL,
	FollowingId				UNIQUEIDENTIFIER	NOT NULL,
	StatusFollow			NVARCHAR(20)		NOT NULL,--PENDING || ACCEPTED
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Followings PRIMARY KEY (FollowerId, FollowingId),
	CONSTRAINT FK_Followings_Users FOREIGN KEY (FollowerId)
		REFERENCES Users(IdUser),
	CONSTRAINT FK_Followings_Users2 FOREIGN KEY ( FollowingId)
		REFERENCES Users(IdUser),

	CONSTRAINT CK_NoSelfFollow CHECK (FollowingId != FollowerId),
	CHECK (StatusFollow IN ('PENDING','ACCEPTED'))
);
GO

-- ============================================================
--  TABLA: Conversations
-- ============================================================

CREATE TABLE Conversations(
	ConversationId			UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	ConversationName		NVARCHAR(50)		NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Conversations PRIMARY KEY (ConversationId)
);
GO

-- ============================================================
--  TABLA: ConversationUsers
-- ============================================================

CREATE TABLE ConversationUsers(
	ConversationId			UNIQUEIDENTIFIER	NOT NULL,
	IdUser					UNIQUEIDENTIFIER	NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,
	
	CONSTRAINT PK_ConversationUsers PRIMARY KEY (ConversationId, IdUser),
	CONSTRAINT FK_ConversationUsers_Conversations FOREIGN KEY (ConversationId)
		REFERENCES Conversations(ConversationId),
	CONSTRAINT FK_ConversationUsers_Users FOREIGN KEY (IdUser)
		REFERENCES Users(IdUser)
);
GO

-- ============================================================
--  TABLA: LetterMessages
-- ============================================================

CREATE TABLE LetterMessages(
	MessageId				UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	ConversationId			UNIQUEIDENTIFIER	NOT NULL,
	SenderId				UNIQUEIDENTIFIER	NOT NULL,
	Content					NVARCHAR(1000)		NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_LetterMessages PRIMARY KEY (MessageId),
	CONSTRAINT FK_LetterMessages_Conversations FOREIGN KEY (ConversationId)
		REFERENCES Conversations(ConversationId),
	CONSTRAINT FK_LetterMessages_Users FOREIGN KEY (SenderId)
		REFERENCES Users(IdUser)
);
GO

-- ============================================================
--  TABLA: Posts -COMPLETADO
-- ============================================================

CREATE TABLE Posts(
	PostId					UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	IsStory					BIT					NOT NULL,--0:NO STORY || 1:SI STORY
	UserId					UNIQUEIDENTIFIER	NOT NULL,
	PostDescription			NVARCHAR(1000)		NOT NULL,
	LocationName			NVARCHAR(250)		NULL,
	Latitude				DECIMAL(9,6)		NULL,
	Longitude				DECIMAL(9,6)		NULL,
	MediaUrl				NVARCHAR(500)		NOT NULL,
	ExpiresAt				DATETIME2			NULL, --esto depende de IsStory se debe cesar el story despues de 24h
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Posts PRIMARY KEY (PostId),

	CONSTRAINT FK_Posts_Users FOREIGN KEY (UserId)
		REFERENCES Users(IdUser), 

	CHECK ((IsStory = 1 AND ExpiresAt IS NOT NULL) OR
    (IsStory = 0 AND ExpiresAt IS NULL))
);
GO

-- ============================================================
--  TABLA: PostHashtags -COMPLETADO
-- ============================================================

CREATE TABLE PostHashtags(
	PostId					UNIQUEIDENTIFIER	NOT NULL,
	HashtagId				INT					NOT NULL,

	CONSTRAINT PK_PostHashtags PRIMARY KEY (PostId, HashtagId),

	CONSTRAINT FK_PostHashtags_Posts FOREIGN KEY (PostId)
		REFERENCES Posts(PostId),
	CONSTRAINT FK_PostHashtags_Hashtags FOREIGN KEY (HashtagId)
		REFERENCES Hashtags(HashtagId)
);
GO

-- ============================================================
--  TABLA: PostMentions -COMPLETADO
-- ============================================================

CREATE TABLE PostMentions(
	PostId					UNIQUEIDENTIFIER	NOT NULL,
	UserId					UNIQUEIDENTIFIER	NOT NULL,

	CONSTRAINT PK_PostMentions PRIMARY KEY (PostId, UserId),

	CONSTRAINT FK_PostMentions_Posts FOREIGN KEY (PostId)
		REFERENCES Posts(PostId),
	CONSTRAINT FK_PostMentions_Users FOREIGN KEY (UserId)
		REFERENCES Users(IdUser)
);
GO

-- ============================================================
--  TABLA: Likes
-- ============================================================

CREATE TABLE Likes(
	UserId					UNIQUEIDENTIFIER	NOT NULL,
	ReactionId				INT					NOT NULL,
	PostId					UNIQUEIDENTIFIER	NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Likes PRIMARY KEY (UserId, PostId),

	CONSTRAINT FK_Likes_Users FOREIGN KEY (UserId)
		REFERENCES Users(IdUser),
	CONSTRAINT FK_Likes_TypeReations FOREIGN KEY (ReactionId)
		REFERENCES TypeReactions(ReactionId),
	CONSTRAINT FK_Likes_Post FOREIGN KEY (PostId)
		REFERENCES Posts(PostId)

);
GO

-- ============================================================
--  TABLA: Comments
-- ============================================================

CREATE TABLE Comments(
	CommentId				UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID(),
	PostId					UNIQUEIDENTIFIER	NOT NULL,
	IdUser					UNIQUEIDENTIFIER	NOT NULL,
	ParentCommentId			UNIQUEIDENTIFIER	NULL,
	Content					NVARCHAR(1000)		NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_Comments PRIMARY KEY (CommentId),

	CONSTRAINT FK_Comments_Posts FOREIGN KEY (PostId)
		REFERENCES Posts(PostId),
	CONSTRAINT FK_Comments_Users FOREIGN KEY (IdUser)
		REFERENCES Users(IdUser),
	CONSTRAINT FK_Comments_Parent FOREIGN KEY (ParentCommentId)
		REFERENCES Comments(CommentId) ON DELETE NO ACTION
);
GO

-- ============================================================
--  TABLA: SavedPosts
-- ============================================================

CREATE TABLE SavedPosts(
	IdUser					UNIQUEIDENTIFIER	NOT NULL,
	PostId					UNIQUEIDENTIFIER	NOT NULL,
	CreatedAt				DATETIME2			NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt				DATETIME2			NULL,

	CONSTRAINT PK_SavedPosts PRIMARY KEY (IdUser, PostId),

	CONSTRAINT FK_SavedPosts_Users FOREIGN KEY (IdUser)
		REFERENCES Users(IdUser),
	CONSTRAINT FK_SavedPosts_Posts FOREIGN KEY (PostId)
		REFERENCES Posts(PostId)
);
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- ============================================================
--  Rellenado: TypeUsers
-- ============================================================
--TIPOS DE USUARIOS: REGULAR: sin stats pro| CONTENTCREATOR:sin stats pro | BUSINESS: con stats pro
INSERT INTO TypeUsers(NameType,StatisticsProActive) 
	VALUES('REGULAR',0),
	('CONTENT_CREATOR',0),
	('BUSINESS_ACCOUNT',1),
	('ADMINISTRATOR',1);
GO
-- ============================================================
--  Rellenado: TypeReactions
-- ============================================================
INSERT INTO TypeReactions(ReactionDescription)
	VALUES('INTERESANTE'),
	('CELEBRAR'),
	('HACER GRACIA'),
	('ME ENCANTA');
GO

--Esto lo use para corregir un constraint que se me paso
--ALTER TABLE TypeReactions
--	ADD CONSTRAINT UQ_ReactionDescription UNIQUE (ReactionDescription);
--GO  

-- ============================================================
--  Indices(Para rendimiento "todavvia hay que ver como ayuda")
-- ============================================================


CREATE INDEX IX_Posts_UserId ON Posts(UserId);
CREATE INDEX IX_Comments_PostId ON Comments(PostId);
CREATE INDEX IX_Likes_PostId ON Likes(PostId);
CREATE INDEX IX_Followings_FollowingId ON Followings(FollowingId);


-- ============================================================
--  Cambios posteriores 
-- ============================================================

ALTER TABLE Users
ALTER COLUMN UserUnName NVARCHAR(50) NOT NULL;

ALTER TABLE Users
ADD CONSTRAINT UQ_UserUnName UNIQUE(UserUnName);