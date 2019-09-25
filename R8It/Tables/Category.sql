﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE, 
	[Active] BIT NOT NULL DEFAULT 1,
	[Icon] VARCHAR(50) NOT NULL DEFAULT 'placeholder.png'
)
