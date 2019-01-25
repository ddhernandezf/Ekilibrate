﻿CREATE TABLE [dbo].[PAR.CONDICION_TRATAMIENTO](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[PADECIMIENTO_PRINCIPAL] [varchar](max) NULL,
	[PADECIMIENTO_SECUNDARIO] [varchar](max) NULL,
	[MEDICAMENTO_PRINCIPAL] [varchar](max) NULL,
	[MEDICAMENTO_SECUNDARIO] [varchar](max) NULL,
	CONSTRAINT [PK_PAR.CONDICION_TRATAMIENTO] PRIMARY KEY ([ID_PARTICIPANTE])
)