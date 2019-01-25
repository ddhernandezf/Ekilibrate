CREATE TABLE [dbo].[PAR.TestLiderazgo](
	[ParticipanteId] [numeric](18, 0) NOT NULL,
	[PreguntaId] [numeric](18, 0) NOT NULL,
	[Siempre] [bit] NULL,
	[Frecuentemente] [bit] NULL,
	[CasiNunca] [bit] NULL,
	[Nunca] [bit] NULL,
	CONSTRAINT [FK_PAR_LIDERAZGO_PAR_INFORMACION_GENERAL] FOREIGN KEY ([ParticipanteId]) REFERENCES [PAR.INFORMACION_GENERAL]([ID_PARTICIPANTE]),
	CONSTRAINT [FK_LIDERAZGO_PAR_PREGUNTA_LIDERAZGO] FOREIGN KEY ([PreguntaId]) REFERENCES [PAR.PreguntaLiderazgo]([Id]),
	PRIMARY KEY ([ParticipanteId], [PreguntaId])
)