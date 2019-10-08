CREATE TABLE [dbo].[Subscription]
(
	[CategoryId] INT NOT NULL,
	[UserId] INT NOT NULL,
	
	CONSTRAINT [FK_Subscription_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Subscription_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
	
	CONSTRAINT [UK_Subscription] UNIQUE (CategoryId, UserId)
)
