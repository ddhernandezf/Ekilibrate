CREATE TABLE [dbo].[PR.ParticipanteTaller]
(
	[ParticipanteId] INT NOT NULL , 
	[ProyectoId]  INT NOT NULL,
    [TallerId] INT NOT NULL, 
    [Nota] DECIMAL(3, 2) NULL, 
    PRIMARY KEY ([ParticipanteId], [TallerId]),
	CONSTRAINT [FK_PR.ParticipanteTaller_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_PR.ParticipanteTaller_Taller] FOREIGN KEY ([TallerId]) REFERENCES [PR.Taller]([Id]),
)
