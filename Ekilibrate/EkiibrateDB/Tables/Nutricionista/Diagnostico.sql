CREATE TABLE [dbo].[NU.Diagnostico]
(
	[ParticipanteId] INT NOT NULL, 
	[ProyectoId] INT NOT NULL,
	[NutricionistaId] INT NOT NULL, 
    [Peso] DECIMAL(10, 2) NOT NULL, 
    [Estatura] DECIMAL(10, 2) NOT NULL, 
    [CircunferenciaMuneca] DECIMAL(10, 2) NOT NULL, 
    [CircunferenciaAbdominal] DECIMAL(10, 2) NOT NULL, 
    [PorcentajeGrasa] DECIMAL(10, 2) NOT NULL, 
    [Colesterol] DECIMAL(10, 2) NOT NULL, 
    [Triglicerios] DECIMAL(10, 2) NOT NULL, 
    [Glucosa] DECIMAL(10, 2) NOT NULL, 
    [PresionArterial] DECIMAL(10, 2) NOT NULL, 
    [Observaciones] NVARCHAR(MAX) NOT NULL, 
    [ComentariosRelevantes] NVARCHAR(MAX) NOT NULL,
	[MetabolismoBasal] DECIMAL NULL,
	[CircunferenciaCadera] DECIMAL(10, 2) NOT NULL, 
	[PresionArterial2] DECIMAL(10, 2) NOT NULL, 
	[NivelActividad] INT NULL,
	[Genero] VARCHAR(50) NULL,
	[CitaId] INT NULL
    CONSTRAINT [FK_NU.Diagnostico_Cita] FOREIGN KEY ([CitaId]) REFERENCES [PR.Cita]([Id]),
    CONSTRAINT [FK_NU.Diagnostico_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_NU.Diagnostico_Nutricionista] FOREIGN KEY ([NutricionistaId]) REFERENCES [ADM.Colaborador]([Id]),
	PRIMARY KEY ([ParticipanteId], [ProyectoId])
)
