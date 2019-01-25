CREATE TABLE [dbo].[PR.Semana]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProyectoId] INT NOT NULL, 
    [Semana] INT NOT NULL,	
    [Nombre] NVARCHAR(50) NOT NULL, 
    [FechaInicio] DATE NOT NULL, 
    [FechaFin] DATE NOT NULL
	CONSTRAINT [FK_ADM.Semana_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]), 
)
