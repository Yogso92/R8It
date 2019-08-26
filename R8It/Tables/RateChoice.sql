CREATE TABLE [dbo].[RateChoice]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[RatingTypeId] INT NOT NULL,
	[Text] VARCHAR(20) NOT NULL, 
	[Value] INT NOT NULL,

	CONSTRAINT [FK_RateChoice_RateType] FOREIGN KEY ([RatingTypeId]) REFERENCES [RatingType]([Id])

)
