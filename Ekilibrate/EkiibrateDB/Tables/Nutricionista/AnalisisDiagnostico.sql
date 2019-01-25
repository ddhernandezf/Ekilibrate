CREATE TABLE [dbo].[NU.AnalisisDiagnostico]
(
	[ParticipanteId] INT NOT NULL, 
	[ProyectoId]  INT NOT NULL,
	[NutricionistaId] INT NOT NULL, 
    [PrincipalProblema] NVARCHAR(MAX) NOT NULL, 
    [PlanDeAccion] NVARCHAR(MAX) NOT NULL,
	[Recomendaciones] NVARCHAR(MAX) NOT NULL,
	[HabitosEstablecer] NVARCHAR(MAX) NOT NULL,
	[PlanDeAlimentacion] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [FK_NU.AnalisisDiagnostico_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.AnalisisDiagnostico_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id]),
	PRIMARY KEY ([ParticipanteId], [ProyectoId])
)
