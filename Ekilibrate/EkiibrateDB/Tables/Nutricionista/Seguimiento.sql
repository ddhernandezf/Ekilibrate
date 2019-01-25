CREATE TABLE [dbo].[NU.Seguimiento]
(
	[ParticipanteId] INT NOT NULL,
	[ProyectoId]  INT NOT NULL,
	[CitaId] INT NOT NULL,
	[NutricionistaId] INT NOT NULL,	
    [ComentariosRelevantes] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [FK_NU.Segumiento_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.Seguimiento_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_NU.Seguimiento_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]), 
    PRIMARY KEY ([ParticipanteId], [CitaId]),
)
