﻿CREATE TABLE [dbo].[PAR.TIPO_ENFERMEDAD](
	[ID_ENFERMEDAD] [numeric](18, 0) NOT NULL,
	[ENFERMEDAD] [varchar](max) NULL,
 CONSTRAINT [PK_PAR_TIPO_ENFERMEDAD] PRIMARY KEY CLUSTERED 
(
	[ID_ENFERMEDAD] ASC
) 
) 