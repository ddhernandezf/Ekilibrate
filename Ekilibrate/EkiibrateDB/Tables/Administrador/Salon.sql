CREATE TABLE [dbo].[ADM.Salon]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [Capacidad] INT NOT NULL, 
    [TipoUsoId] INT NOT NULL, 
    [EmpresaId] INT NOT NULL, 
    CONSTRAINT [FK_ADM.Salon_Tipo] FOREIGN KEY ([TipoUsoId]) REFERENCES [CA.TipoUsoSalon]([Id]),
	CONSTRAINT [FK_ADM.Empresa_Salon] FOREIGN KEY ([EmpresaId]) REFERENCES [ADM.Empresa]([Id])
)
