CREATE TABLE [dbo].[PR.Grupo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [ProyectoId] INT NOT NULL, 
	CONSTRAINT [FK_PR.Grupo_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
)
