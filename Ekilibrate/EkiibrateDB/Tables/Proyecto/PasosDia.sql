CREATE TABLE [dbo].[PR.PasosDia]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SemanaId] INT NOT NULL, 
    [ParticipanteId] INT NOT NULL,
	[ProyectoId]  INT NOT NULL,
	[Dia] INT NOT NULL, 
	[Meta] INT NOT NULL, 
    [Caminados] INT NOT NULL, 
    [FechaRegistro] DATETIME NULL,
	CONSTRAINT [FK_PR.PasosDia_Semana] FOREIGN KEY ([SemanaId]) REFERENCES [PR.Semana]([Id]), 
    CONSTRAINT [FK_PR.PasosDia_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
)
