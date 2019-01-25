CREATE TABLE [dbo].[PR.Cita]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[CicloId] INT NOT NULL, 
    [ParticipanteId] INT NOT NULL,
	[ProyectoId] INT NOT NULL,
	[FechaProgramada] DATETIME NOT NULL, 
    [NotaGlobal] DECIMAL(3, 2) NULL, 
    [Ranking] INT NULL, 
	[TipoCitaId] INT,
	CONSTRAINT [FK_PR.Cita_Ciclo] FOREIGN KEY (CicloId) REFERENCES [PR.Ciclo]([Id]),
    CONSTRAINT [FK_PR.Cita_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_PR.Cita_TipoCita] FOREIGN KEY (TipoCitaId) REFERENCES [CA.TipoCita]([Id])
)
