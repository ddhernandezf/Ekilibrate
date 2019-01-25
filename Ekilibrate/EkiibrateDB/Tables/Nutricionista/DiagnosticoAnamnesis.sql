CREATE TABLE [dbo].[NU.DiagnosticoAnamnesis]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ParticipanteId] INT NOT NULL,
	[ProyectoId] INT NOT NULL,
	[NutricionistaId] INT NOT NULL,
    [GrupoAlimentoId] INT NOT NULL, 
    [TiempoComidaId] INT NOT NULL, 
    [Porciones] INT NOT NULL,
	[CitaId] INT NULL
    CONSTRAINT [FK_NU.DiagnosticoAnamnesis_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]),
	CONSTRAINT [FK_NU.DiagnosticoAnamnesis_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.DiagnosticoAnamnesis_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_NU.DiagnosticoAnamnesis_GrupoAlimento] FOREIGN KEY ([GrupoAlimentoId]) REFERENCES [CA.GrupoAlimento]([Id]),
	CONSTRAINT [FK_NU.DiagnosticoAnamnesis_TiempoComida] FOREIGN KEY ([TiempoComidaId]) REFERENCES [CA.TiempoComida]([Id]),
)
