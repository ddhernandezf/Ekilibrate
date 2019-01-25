CREATE TABLE [dbo].[GE.Error]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Mensaje] NVARCHAR(500) NOT NULL, 
    [Pila] NVARCHAR(MAX) NULL, 
    [Exepcion] NVARCHAR(MAX) NULL, 
    [Fecha] DATETIME NOT NULL
)
