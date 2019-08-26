CREATE TABLE [dbo].[Vote]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL,
	[UploadId] INT NOT NULL,
	[Comment] VARCHAR(255) NULL,
	[RateChoiceId] INT NOT NULL,

	CONSTRAINT [FK_Vote_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Vote_Upload] FOREIGN KEY ([UploadId]) REFERENCES [Upload]([Id]),
	CONSTRAINT [FK_Vote_RateChoice] FOREIGN KEY ([RateChoiceId]) REFERENCES [RateChoice]([Id])

)
