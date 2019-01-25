CREATE TABLE [dbo].[ADM.Contacto]
(	
	[EmpresaId] INT NOT NULL, 
    [PersonaId] INT NOT NULL PRIMARY KEY,     
	[EsPrincipal] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ADM.Contacto_Empresa] FOREIGN KEY ([EmpresaId]) REFERENCES [ADM.Empresa]([Id]),
	CONSTRAINT [FK_ADM.Contacto_Persona] FOREIGN KEY ([PersonaId]) REFERENCES [GE.Persona]([Id])
)
