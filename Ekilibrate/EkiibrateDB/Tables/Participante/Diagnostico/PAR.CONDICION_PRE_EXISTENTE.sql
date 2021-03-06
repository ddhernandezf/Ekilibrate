﻿CREATE TABLE [dbo].[PAR.CONDICION_PRE_EXISTENTE](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[ID_CONDICION] [numeric](18, 0) NOT NULL,
	[RESPUESTA] [bit] NULL,
	CONSTRAINT [FK_PAR_CONDICION_PRE_EXISTENTE_PAR_CONDICION] FOREIGN KEY ([ID_CONDICION]) REFERENCES [PAR.CONDICION]([ID_CONDICION]),
	CONSTRAINT [FK_PAR_CONDICION_PRE_EXISTENTE_PAR_INFORMACION_GENERAL] FOREIGN KEY ([ID_PARTICIPANTE]) REFERENCES [PAR.INFORMACION_GENERAL]([ID_PARTICIPANTE]),
	PRIMARY KEY ([ID_PARTICIPANTE], [ID_CONDICION])
)