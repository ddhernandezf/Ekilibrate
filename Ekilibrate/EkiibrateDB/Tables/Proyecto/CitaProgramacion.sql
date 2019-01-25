CREATE TABLE [dbo].[PR.CitaProgramacion]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[CitaId] INT NOT NULL, 
    [NutricionistaId] INT NOT NULL,     
    [Fecha] DATETIME NOT NULL, 
	[Cancelada] BIT NOT NULL DEFAULT 0,
	[FechaInicio] DATETIME NULL, 
	[FechaFin] DATETIME NULL, 
	CONSTRAINT [FK_PR.CitaProgramacion_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]),
	CONSTRAINT [FK_PR.CitaProgramacion_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id])
)
