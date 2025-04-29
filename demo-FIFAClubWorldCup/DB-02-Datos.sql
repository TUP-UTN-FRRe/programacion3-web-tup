
--Eliminacion de Datos
------------------------------------------
DELETE dbo.Equipo
DELETE dbo.Pais
GO



SET IDENTITY_INSERT dbo.Pais ON
GO 

INSERT INTO dbo.Pais 
(PaisId, Nombre)
VALUES 
(1, 'Argentina')
GO

SET IDENTITY_INSERT dbo.Pais OFF
GO 



SET IDENTITY_INSERT dbo.Equipo ON
GO 

INSERT INTO dbo.Equipo 
(EquipoId, Nombre, PaisId, ImagenUrl)
VALUES 
(1, 'CA Boca Juniors', 1, 'https://media.ticketmaster.com/en-us/dam/a/fa2/360eed6a-c258-4ae7-a467-7be3316fafa2_758681_CUSTOM.jpg')
GO

INSERT INTO dbo.Equipo 
(EquipoId, Nombre, PaisId, ImagenUrl)
VALUES 
(2, 'SL Benfica', 1, 'https://s1.ticketm.net/dam/a/a39/f4b451f1-5d21-4e62-8da4-a839fdae4a39_RETINA_PORTRAIT_3_2.jpg')
GO

SET IDENTITY_INSERT dbo.Equipo  OFF
GO 

