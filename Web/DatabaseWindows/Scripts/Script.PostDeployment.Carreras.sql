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

MERGE INTO Carreras AS Target
USING (VALUES
    ('420705','Bachillerato en Computación con varios énfasis','Escuela de Ciencias de la Computación e Informática',1,0),
    ('507024','Ingenieria eléctrica','Escuela de Ingeniería Eléctrica',1,0),
    ('341001','Sociologia','Escuela de Ciencias Sociales',0,0),
    ('340301','Ciencias Politicas','Escuela de Ciencias Sociales',0,0),
    ('600123','Gestion de los Recursos Naturales','Escuela de Ciencias Ambientales',0,0)
)
AS SOURCE ([Codigo],[Nombre],[Escuela],[IsSteam],[PresupuestoBecas])
ON Target.[Codigo] = SOURCE.[Codigo]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Codigo],[Nombre],[Escuela],[IsSteam],[PresupuestoBecas])
    VALUES (SOURCE.[Codigo],SOURCE.[Nombre],SOURCE.[Escuela],Source.[IsSteam],Source.[PresupuestoBecas])
WHEN MATCHED THEN
    UPDATE SET
    [Nombre] = SOURCE.[Nombre],
    [Escuela] = SOURCE.[Escuela],
    [IsSteam] = SOURCE.[IsSteam],
    [PresupuestoBecas] = SOURCE.[PresupuestoBecas];
