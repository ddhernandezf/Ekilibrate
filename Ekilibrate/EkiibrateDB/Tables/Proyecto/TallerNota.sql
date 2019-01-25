CREATE TABLE [dbo].[PR.TallerNota]
(
	[TallerId] INT NOT NULL,
	[NoSesion] INT NOT NULL, 
	[ParticipanteId] INT NOT NULL, 
	[Asistencia] DECIMAL(18, 2) NOT NULL, 
    [Tarea] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_PR.TallerNota_Taller] FOREIGN KEY ([TallerId]) REFERENCES [PR.Taller]([Id]), 
    CONSTRAINT [PK_TallerNota] PRIMARY KEY ([TallerId], [ParticipanteId], [NoSesion]) 
)
