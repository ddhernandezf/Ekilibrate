CREATE TABLE [dbo].[PR.Desempeño]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ParticipanteId] INT NOT NULL, 
	[ProyectoId] INT NOT NULL,
    [SemanaId] INT NOT NULL, 
    [Taller] FLOAT NOT NULL, 
    [Pasos] FLOAT NOT NULL, 
    [Alimentacion] FLOAT NOT NULL,
	CONSTRAINT [FK_PR.Desempeño_Participante] FOREIGN KEY ([ParticipanteId], [ProyectoId]) REFERENCES [PAR.Participante]([Id], [ProyectoId]),
	CONSTRAINT [FK_PR.Desempeño_Semana] FOREIGN KEY ([SemanaId]) REFERENCES [PR.Semana]([Id]), 
)
