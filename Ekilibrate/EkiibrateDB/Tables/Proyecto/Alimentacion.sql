CREATE TABLE [dbo].[PR.Alimentacion]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ParticipanteId] INT NOT NULL,
	[ProyectoId] INT NOT NULL,  
    [SemanaId] INT NOT NULL, 
    [Meta] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [Comido] DECIMAL(18, 2) NOT NULL DEFAULT 0,
	CONSTRAINT [FK_PR.Alimentacion_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
)
