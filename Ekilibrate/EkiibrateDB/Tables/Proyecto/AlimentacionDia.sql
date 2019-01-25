CREATE TABLE [dbo].[PR.AlimentacionDia]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ParticipanteId] INT NOT NULL,
	[ProyectoId] INT NOT NULL,
    [GrupoAlimentoId] INT NOT NULL,
    [SemanaId] INT NOT NULL, 
    [Dia] INT NOT NULL, 
    [Meta] DECIMAL(18, 2) NULL, 
    [Comido] DECIMAL(18, 2) NULL,
	CONSTRAINT [FK_PR.AlimentacionDia_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_PR.AlimentacionDia_GrupoAlimento] FOREIGN KEY ([GrupoAlimentoId]) REFERENCES [CA.GrupoAlimento]([Id]), 
)
