CREATE TABLE [dbo].[Contenidos]
(
	[Acronimo] CHAR(6) NOT NULL,
    [Nombre] VARCHAR(100) NOT NULL, 
    [Creditos] TINYINT NOT NULL,
    [Tipo] CHAR(1) DEFAULT 'o', -- t=tecnologico, s=social, a=ambiental y o=otro
    CONSTRAINT PK_Contenidos PRIMARY KEY (Acronimo)
)
