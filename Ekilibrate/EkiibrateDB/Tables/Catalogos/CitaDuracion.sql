CREATE TABLE [dbo].[CA.CitaDuracion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [Tiempo] TIME(5) NOT NULL, 
    [Cantidad] FLOAT NOT NULL, 
    [UnidadTiempoId] INT NOT NULL
)
