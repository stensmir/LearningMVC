CREATE TABLE [HabrLesson].[User]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR(50) not null,
	[LastName] varchar(50) not null,
	[Login] varchar(250) not null,
	[LinkToAvatar] varchar(max)
)
