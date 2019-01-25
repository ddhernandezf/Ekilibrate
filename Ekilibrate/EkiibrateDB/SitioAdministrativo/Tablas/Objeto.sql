CREATE TABLE [Administracion].[Objeto]
(
	[IdObjeto] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nombre] VARCHAR(45) NOT NULL,
	[Descripcion] VARCHAR(200) NOT NULL,
	[IdProducto] INT NOT NULL, 
	[IdObjetoPadre] INT,
	[Activo] BIT NOT NULL,
	CONSTRAINT FK_Objeto_Producto FOREIGN KEY ([IdProducto]) REFERENCES [Administracion].[Producto]([IdProducto]),
	CONSTRAINT FK_Objeto_Padre FOREIGN KEY ([IdObjetoPadre]) REFERENCES [Administracion].[Objeto]([IdObjeto])

)
