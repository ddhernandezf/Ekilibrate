CREATE TABLE [dbo].[ADM.Colaborador]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nutricionista] BIT NOT NULL DEFAULT 0, 
    [Facilitador] BIT NOT NULL DEFAULT 0, 
    [Asistente] BIT NOT NULL DEFAULT 0, 
    [Enfermero(a)] BIT NOT NULL DEFAULT 0, 
    [Estado] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_ADM.Colaborador] FOREIGN KEY ([Id]) REFERENCES [GE.Persona]([Id]),
)
