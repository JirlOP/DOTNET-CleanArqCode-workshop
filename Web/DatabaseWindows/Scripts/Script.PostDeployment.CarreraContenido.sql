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

MERGE INTO CarreraContenido AS Target
USING (VALUES
	('420705', 'EG1'),
    ('420705', 'CI0110'),
	('420705', 'CI0112'),
    ('420705', 'MA1101'),
	('420705', 'MA1005'),
    ('507024', 'EG1'),
    ('507024', 'FS0210'),
    ('507024', 'QU0100'),
	('507024', 'MA1101'),
	('507024', 'MA1005'),
    ('341001', 'EG1'),
    ('341001', 'HA2015'),
	('340301', 'EG1'),
	('340301', 'SO1001'),
    ('340301', 'CP1501'),
	('600123', 'EG1'),
    ('600123', 'RN0001')
)
AS SOURCE ([CarrerasCodigo], [ContenidosAcronimo])
ON TARGET.[CarrerasCodigo] = SOURCE.[CarrerasCodigo]
AND TARGET.[ContenidosAcronimo] = SOURCE.[ContenidosAcronimo]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([CarrerasCodigo], [ContenidosAcronimo])
    VALUES (SOURCE.[CarrerasCodigo], SOURCE.[ContenidosAcronimo]);