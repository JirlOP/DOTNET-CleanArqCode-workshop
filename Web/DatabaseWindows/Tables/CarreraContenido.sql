CREATE TABLE [dbo].[CarreraContenido]
(
	[CarrerasCodigo] CHAR(6) NOT NULL, 
	[ContenidosAcronimo] CHAR(6) NOT NULL,
    CONSTRAINT PK_CarreraContenido PRIMARY KEY (CarrerasCodigo, ContenidosAcronimo),
	CONSTRAINT FK_CarreraContenido_Carreras FOREIGN KEY (CarrerasCodigo) REFERENCES Carreras(Codigo) ON DELETE CASCADE,
	CONSTRAINT FK_CarreraContenido_Contenidos FOREIGN KEY (ContenidosAcronimo) REFERENCES Contenidos(Acronimo) ON DELETE CASCADE
)
