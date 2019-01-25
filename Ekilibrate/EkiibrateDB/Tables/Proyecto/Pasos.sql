CREATE TABLE [dbo].[PR.Pasos]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SemanaId] INT NOT NULL, 
    [ParticipanteId] INT NOT NULL,
	[ProyectoId] INT NOT NULL,
	[Meta] INT NOT NULL, 
    [Caminados] INT NOT NULL, 
    [FechaRegistro] DATETIME NULL,
	[Registros] INT NULL, 
    [Nota] INT NULL, 
    [NotaCompa] INT NULL, 
    CONSTRAINT [FK_PR.Pasos_Semana] FOREIGN KEY ([SemanaId]) REFERENCES [PR.Semana]([Id]), 
    CONSTRAINT [FK_PR.Pasos_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
)
