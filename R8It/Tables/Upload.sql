CREATE TABLE [dbo].[Upload]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UploadDate] DATETIME2 DEFAULT GETDATE(),
	[Context] VARCHAR(max) NOT NULL DEFAULT ' ',
	[UserId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[File] VARBINARY(max) NOT NULL,
	[LimitDate] DATETIME2  DEFAULT GETDATE(),
	[RatingTypeId] INT NOT NULL,
	[Anonymous] BIT NOT NULL DEFAULT 0,
	[Active] BIT NOT NULL DEFAULT 1,
	[Deleted] BIT NOT NULL DEFAULT 0,

	CONSTRAINT [FK_Upload_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Upload_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
	CONSTRAINT [FK_Upload_RatingType] FOREIGN KEY ([RatingTypeId]) REFERENCES [RatingType]([Id])



)
