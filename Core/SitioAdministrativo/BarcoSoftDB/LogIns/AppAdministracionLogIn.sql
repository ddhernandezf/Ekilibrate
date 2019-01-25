CREATE LOGIN [AppAdministracionLogIn] WITH PASSWORD = 'prueba123' , CHECK_POLICY  = OFF
GO
CREATE USER [AppAdministracionLogIn] FOR LOGIN [AppAdministracionLogIn];
GO
GRANT CONNECT TO [AppAdministracionLogIn];
GO