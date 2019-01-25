CREATE TABLE [dbo].[CA.Taller]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Nombre] NVARCHAR(50)  NOT NULL, 
    [AreaId] INT NULL,
	CONSTRAINT [FK_CA.Taller_Area] FOREIGN KEY ([AreaId]) REFERENCES [CA.Area]([Id]), 
)
