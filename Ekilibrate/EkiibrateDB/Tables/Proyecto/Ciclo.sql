CREATE TABLE [dbo].[PR.Ciclo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProyectoId] INT NOT NULL, 
    [FechaInicio] DATETIME NOT NULL, 
    [FechaFin] DATETIME NOT NULL, 
    [Finalizado] BIT NOT NULL, 
    [No] INT NOT NULL

)
