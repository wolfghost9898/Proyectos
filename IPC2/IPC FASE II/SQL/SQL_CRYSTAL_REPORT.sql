Use Fase2;
Select * From Usuario;
Select * From Comparaciones;
Select * From ComparacionSoftware;


SELECT Software.nombre,Licencia.descricpcion,Empresa_Propietaria.nombre,
(SELECT COUNT(Retroalimentacion.codso)  From Retroalimentacion Where Retroalimentacion.codso=Software.id_software),
(SELECT COUNT(ComparacionSoftware.idsoft) From ComparacionSoftware WHERE ComparacionSoftware.idsoft=Software.id_software), 
(SELECT COUNT(Comparaciones.Ap_ganadora) From Comparaciones Where Comparaciones.Ap_ganadora=Software.nombre)
From Software
 Join LicenciaSoftware On LicenciaSoftware.idsoftware=Software.id_software
 Join Licencia On Licencia.id_licencia=LicenciaSoftware.idlicencia
 Join Empresa_Propietaria On Empresa_Propietaria.id_Empresa=Software.codempresa



 SELECT Usuario.nombre,Usuario.Correo,Usuario.Profesion,
 (SELECT COUNT(Retroalimentacion.codusuario) From Retroalimentacion Where Retroalimentacion.codusuario=Usuario.id_usuario),
 (SELECT COUNT(Comparaciones.idusuario) From Comparaciones WHERE Comparaciones.idusuario=Usuario.id_usuario),
 (SELECT COUNT(Recomendacion.coduser) FROM Recomendacion WHERE Recomendacion.coduser=Usuario.id_usuario)
 FROM Usuario