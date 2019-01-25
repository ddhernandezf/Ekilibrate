CREATE TABLE [dbo].[NU.DiagnosticoAlimentacion]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ParticipanteId] INT NOT NULL, 
	[ProyectoId] INT NOT NULL,
	[NutricionistaId] INT NOT NULL,
    [AlimentoId] INT NOT NULL, 
    [Porciones] INT NOT NULL,
	[Dias] INT NOT NULL,
	[CitaId] INT NULL
    CONSTRAINT [FK_NU.DiagnosticoAlimentacion_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]),
	CONSTRAINT [FK_NU.DiagnosticoAlimentacion_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.DiagnosticoAlimentacion_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_NU.DiagnosticoAlimentacion_Alimento] FOREIGN KEY ([AlimentoId]) REFERENCES [CA.Alimento]([Id]),
)
