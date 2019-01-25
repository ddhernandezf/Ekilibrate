CREATE TABLE [dbo].[CA.Area]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(50)  NOT NULL, 
    [Restrictiva] BIT NOT NULL DEFAULT 0, 
    [Talleres] BIT NOT NULL DEFAULT 0
)
