CREATE TABLE [dbo].[VisibilityLimit]
(
	[UploadId] INT NOT NULL,
	[CountryId] INT NOT NULL,
	
	CONSTRAINT [FK_VisibilityLimit_Upload] FOREIGN KEY ([UploadId]) REFERENCES [Upload]([Id]),
	CONSTRAINT [FK_VisibilityLimit_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id]),
	CONSTRAINT [UK_Visibility] UNIQUE(UploadId, CountryId)
)
