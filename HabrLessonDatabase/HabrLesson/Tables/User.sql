CREATE TABLE [HabrLesson].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[GivenName] VARCHAR(50) not null,
	[FamilyName] varchar(50) not null,
	[Email] varchar(250) not null,
	[LinkToAvatar] varchar(max) null,
	[GoogleId] varchar(max) null
)
