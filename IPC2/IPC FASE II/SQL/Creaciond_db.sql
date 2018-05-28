create database Fase2;
go
use Fase2;
go

create table TipoUsuario (
id_tipousuario int not null PRiMARY KEY,
tipo varchar (50)

);
INSERT INTO TipoUsuario(id_tipousuario, tipo) values ('001','Administrador'),('002','Basico'),('003','Premium');
select*from TipoUsuario

create table Usuario (
id_usuario varchar (50) not null PRiMARY KEY,
nombre varchar (50) not null ,
Fecha_NAc varchar(50),
Correo varchar(50),
Contraseña varchar (50),
Profesion varchar (50),
idtipousuario INT
CONSTRAINT FK_Usuario_idtipousuario FOREIGN KEY (idtipousuario) REFERENCES TipoUsuario(id_tipousuario)

);
INSERT INTO Usuario(id_usuario,nombre,Fecha_NAc,Correo,Contraseña,Profesion,idtipousuario) values ('Admin','Admin','10-10-1990','correo','123','ingeniero','001'),
('premium','premium','10-10-1990','correo','1234','ingeniero','003');
select*from Usuario

create table Precio (
id_Precio int not null PRiMARY KEY IDENTITY(1,1) ,
nombre varchar (50),
Premium varchar(50),
Basico varchar (50),
idusuario varchar(50)
CONSTRAINT FK_Precio_idusuario FOREIGN KEY (idusuario) REFERENCES Usuario(id_usuario)

);

create table Empresa_Propietaria (
id_Empresa int not null PRiMARY KEY IDENTITY(1,1) ,
nombre varchar (50),
sitioweb varchar (50),
Link varchar(50),
valor int,
año_fundacio int,


);


create table Software (
id_software int not null PRiMARY KEY IDENTITY(1,1) ,
nombre varchar (50),
Descripcion varchar (50),
Link varchar(50),
Demo varchar (50),
Soporte varchar (50),
Año_Creacion INT,
Imagen varchar (50),

codempresa int
CONSTRAINT FK_Software_codempresa FOREIGN KEY (codempresa) REFERENCES Empresa_Propietaria(id_Empresa)
);

create table Licencia (
id_licencia int not null PRiMARY KEY IDENTITY(1,1) ,
descricpcion varchar(50)
);


create table Plataforma (
id_Plataforma int not null PRiMARY KEY IDENTITY(1,1) ,
tipo varchar(50)
);

create table Software_Plataforma (
id_softwareplataforma int not null PRiMARY KEY IDENTITY(1,1) ,

idsoftware int,
idplataforma int,

CONSTRAINT FK_Software_Plataforma_idsoftware FOREIGN KEY (idsoftware) REFERENCES Software(id_software),
CONSTRAINT FK_Software_Plataforma_idplataforma FOREIGN KEY (idplataforma) REFERENCES Plataforma(id_Plataforma)
);


create table Categoria (
id_venta int not null PRiMARY KEY IDENTITY(1,1) ,
orden varchar(50),
Nombre varchar (50),

);

create table CategoriaSoftware (
id_categoriasoftware int not null PRiMARY KEY IDENTITY(1,1) ,

idcategoria int,
idsoft INT,
CONSTRAINT FK_CategoriaSoftware_idsoft FOREIGN KEY (idsoft) REFERENCES Software(id_Software),
CONSTRAINT FK_CategoriaSoftware_idcategoria FOREIGN KEY (idcategoria) REFERENCES Categoria(id_venta)

);


create table SoftwareUsuario(
id_softwareusuario int not null PRiMARY KEY IDENTITY(1,1) ,
codusuario varchar(50),
codsoftware INT,

CONSTRAINT FK_SoftwareUsuario_coduuario FOREIGN KEY (codusuario) REFERENCES Usuario(id_usuario),
CONSTRAINT FK_SoftwareUsuario_codsoftware FOREIGN KEY (codsoftware) REFERENCES Software(id_Software)

);

create table Frecuencia(
id_frecuencia int not null PRiMARY KEY ,
tipo varchar (50)	
);

create table Retroalimentacion (
id_retroalimentacion int not null PRiMARY KEY IDENTITY(1,1) ,
Ventaja varchar (50),
Desventaja varchar (50),
Comentario varchar (50),
codusuario varchar(50),
fecha varchar (50),
codfrecuencia int,
codso int,

CONSTRAINT FK_Retroalimentacion_codusuario FOREIGN KEY (codusuario) REFERENCES Usuario(id_usuario),
CONSTRAINT FK_Retroalimentacion_codfrecuencia FOREIGN KEY (codfrecuencia) REFERENCES Frecuencia(id_frecuencia),
CONSTRAINT FK_Retroalimentacion_codso FOREIGN KEY (codso) REFERENCES Software(id_software)

);

create table Metricas (
id_metricas int not null PRiMARY KEY IDENTITY(1,1) ,
Nombre varchar (50),
Descripcion varchar (50),

);

create table Retro_metricas (
id_retrometri int not null PRiMARY KEY IDENTITY(1,1) ,
puntaje int,
idrealim int,
idmetca int
CONSTRAINT FK_Retro_metricas_idrealim FOREIGN KEY (idrealim) REFERENCES Retroalimentacion(id_retroalimentacion),
CONSTRAINT FK_Retro_metricas_idmetca FOREIGN KEY (idmetca) REFERENCES Metricas(id_metricas),
);


create table Recomendacion (
id_recomendacion int not null PRiMARY KEY IDENTITY(1,1) ,
Comentario varchar (50),
fecha varchar (50),
coduser varchar (50),
idsoft int,
CONSTRAINT FK_Reco_Soft_idsoft FOREIGN KEY (idsoft) REFERENCES Software(id_software), 
CONSTRAINT FK_Recomendacion_coduser FOREIGN KEY (coduser) REFERENCES Usuario(id_usuario)
);

INSERT INTO Frecuencia(id_frecuencia, tipo) values ('01','Diario'),('02','Mensual'),('03','Anual');
select*from Frecuencia


create table Comparaciones (
id_comparacion int not null PRiMARY KEY IDENTITY(1,1) ,
Ap_ganadora varchar (50),
Fecha varchar(50),
idusuario varchar(50),
CONSTRAINT FK_Comparaciones_idusuario FOREIGN KEY (idusuario) REFERENCES Usuario(id_usuario)

);

create table ComparacionSoftware (
id_comparacionsoftware int not null PRiMARY KEY IDENTITY(1,1) ,
idcompa int,
idsoft int,

CONSTRAINT FK_ComparacionSoftware_idcompa FOREIGN KEY (idcompa) REFERENCES Comparaciones(id_comparacion),
CONSTRAINT FK_ComparacionSoftware_idsoft FOREIGN KEY (idsoft) REFERENCES Software(id_software)
);

create table TemporalSoftware (
id_tempsoftware int not null PRiMARY KEY IDENTITY(1,1) ,
idus varchar(50),
idsoft int,

CONSTRAINT FK_TemporalSoftware_idus FOREIGN KEY (idus) REFERENCES Usuario(id_usuario),
CONSTRAINT FK_TemporalSoftware_idsoft FOREIGN KEY (idsoft) REFERENCES Software(id_software)
);

create table LicenciaSoftware (
id_licenciasoftware int not null PRiMARY KEY IDENTITY(1,1) ,
idlicencia int,
idsoftware int,

CONSTRAINT FK_LicenciaSoftware_idlicencia FOREIGN KEY (idlicencia) REFERENCES Licencia(id_licencia),
CONSTRAINT FK_LicenciaSoftware_idsoftware FOREIGN KEY (idsoftware) REFERENCES Software(id_software)
);