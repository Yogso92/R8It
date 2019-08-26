CREATE TABLE [dbo].[Country]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Code] INT NOT NULL,
	[Alpha2] VARCHAR(2) NOT NULL,
	[Alpha3] varchar(3) NOT NULL,
	[langCS] varchar(45) NOT NULL,
	[langDE] varchar(45) NOT NULL,
	[langEN] varchar(45) NOT NULL,
	[langES] varchar(45) NOT NULL,
	[langFR] varchar(45) NOT NULL,
	[langIT] varchar(45) NOT NULL,
	[langNL] varchar(45) NOT NULL,
)
