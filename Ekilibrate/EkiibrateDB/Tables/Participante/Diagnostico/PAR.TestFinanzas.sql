CREATE TABLE [dbo].[PAR.TestFinanzas]
(
	[ParticipanteId] INT NOT NULL , 
    [PreguntaId] INT NOT NULL, 
    [RespuestaId] INT NOT NULL, 
    PRIMARY KEY ([PreguntaId], [ParticipanteId])
)
