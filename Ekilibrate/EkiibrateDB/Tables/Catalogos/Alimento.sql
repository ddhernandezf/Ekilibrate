CREATE TABLE [dbo].[CA.Alimento]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[GrupoAlimentoId] INT NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL,
	[GrasasSaturadas] BIT NOT NULL DEFAULT 0, 
	[Azucar] BIT NOT NULL DEFAULT 0, 
	[Sal] BIT NOT NULL DEFAULT 0, 
	[Fibra] BIT NOT NULL DEFAULT 0, 
	[TamañoPorcion] NVARCHAR(50) NOT NULL, 
)