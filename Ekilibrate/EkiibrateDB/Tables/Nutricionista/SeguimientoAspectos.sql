CREATE TABLE [dbo].[NU.SeguimientoAspectos]
(
	[ParticipanteId] INT NOT NULL,
	[ProyectoId]  INT NOT NULL,
	[CitaId] INT NOT NULL,
	[AspectoId] INT NOT NULL,
	[Logro] DECIMAL(3, 2) NOT NULL,
	[Meta] DECIMAL(3, 2) NOT NULL,
	[Observaciones] NVARCHAR(MAX),
	CONSTRAINT [FK_NU.SegumientoAspectos_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.SeguimientoAspectos_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]), 
	CONSTRAINT [FK_NU.SeguimientoASpectos_Aspectos] FOREIGN KEY ([AspectoId]) REFERENCES [CA.Aspecto]([Id]), 
    PRIMARY KEY ([ParticipanteId], [CitaId], [AspectoId]),

)
