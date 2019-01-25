CREATE TABLE [dbo].[PAR.RespuestaFinanzas]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PreguntaId] INT NOT NULL, 
    [Nombre] NVARCHAR(500) NOT NULL,
	[Literal] CHAR(1) NOT NULL DEFAULT 'a',
)
