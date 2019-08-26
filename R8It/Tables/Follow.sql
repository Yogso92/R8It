CREATE TABLE [dbo].[Follow]
(
	[FollowerId] INT NOT NULL,
	[FollowedId] INT NOT NULL,


	CONSTRAINT [FK_Follower_User] FOREIGN KEY ([FollowerId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Followed_User] FOREIGN KEY ([FollowedId]) REFERENCES [User]([Id])
)
