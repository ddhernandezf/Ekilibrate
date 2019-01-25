CREATE TABLE [dbo].[PR.TallerProgramacion]
(
	[TallerId] INT NOT NULL,
	[NoSesion] INT NOT NULL, 
	[HoraInicio] DATETIME NOT NULL,
	[HoraFin] DATETIME NOT NULL,
	CONSTRAINT [FK_PR.TallerProgramacion_Taller] FOREIGN KEY ([TallerId]) REFERENCES [PR.Taller]([Id]), 
    CONSTRAINT [PK_PR.TallerProgramacion] PRIMARY KEY ([TallerId], [NoSesion]),)
