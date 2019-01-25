CREATE TABLE [dbo].[PAR.TestTemaFinanzas]
(
	[ParticipanteId] INT NOT NULL, 
    [TemaId] INT NOT NULL, 
    [Interes] BIT NOT NULL
	PRIMARY KEY ([ParticipanteId], [TemaId])
)
