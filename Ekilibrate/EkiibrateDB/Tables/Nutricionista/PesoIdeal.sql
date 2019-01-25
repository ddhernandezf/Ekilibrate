CREATE TABLE [dbo].[NU.PesoIdeal]
(
	[Sexo] NVARCHAR(50) NOT NULL , 
    [Talla] INT NOT NULL, 
    [ContexturaId] INT NOT NULL,
	[Inferior] DECIMAL(12, 2) NOT NULL, 
    [Superior] DECIMAL(12, 2) NOT NULL, 
    [Ideal] DECIMAL(12, 2) NOT NULL, 
    CONSTRAINT [PK_PesoIdeal] PRIMARY KEY ([Sexo], [Talla], [ContexturaId]), 
)
