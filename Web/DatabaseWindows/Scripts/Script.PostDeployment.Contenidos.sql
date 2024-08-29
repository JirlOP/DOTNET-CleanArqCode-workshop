/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- Tipo: t=tecnologico, s=social y a=ambiental

MERGE INTO Contenidos AS Target
USING (VALUES
    ('EG1','Humanidades 1',6,'s'),
    ('CI0110','Introducción a la Computación',4,'t'),
	('MA1005','Ecuaciones diferenciales',4,'t'),
	('CI0112','Programación I',4,'t'),
	('FS0210','Física General I',4,'t'),
    ('QU0100','Química General',4,'t'),
    ('MA1101','Cálculo I',4,'t'),
    ('HA2015','Historia de Centro America',3,'s'),
    ('SO1001','Introducción a la Sociologia',3,'s'),
    ('CP1501','Epistemologia y logica de pensamiento',3,'s'),
    ('RN0001','Introduccion a los Recursos Naturales',4,'a')
)
AS SOURCE ([Acronimo],[Nombre],[Creditos],[Tipo])
    ON Target.[Acronimo] = SOURCE.[Acronimo]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Acronimo],[Nombre],[Creditos],[Tipo])
    VALUES (SOURCE.[Acronimo],SOURCE.[Nombre],SOURCE.[Creditos],SOURCE.[Tipo])
WHEN MATCHED THEN
    UPDATE SET
    [Nombre] = SOURCE.[Nombre],
    [Creditos] = SOURCE.[Creditos],
    [Tipo] = SOURCE.[Tipo];
