CREATE TABLE [dbo].[Carreras]
(
	[Codigo] CHAR(6) NOT NULL, 
    [Nombre] VARCHAR(100) NOT NULL, 
    [Escuela] VARCHAR(100) NOT NULL,
    [IsSteam] BIT DEFAULT 0 NOT NULL,
    [PresupuestoBecas] FLOAT DEFAULT 0,
    CONSTRAINT PK_Carreras PRIMARY KEY (Codigo)
)
