CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(50) NULL, 
    [price] INT NULL, 
    [description] VARCHAR(50) NULL, 
    [quantity] INT NULL, 
    [type_of_meat] NVARCHAR(50) NULL
)
