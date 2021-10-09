
#DROP DATABASE ComponenteSeguridad;
CREATE DATABASE ComponenteSeguridad;

USE ComponenteSeguridad;

CREATE TABLE Empleado(
pkIdEmpleado varchar(15) PRIMARY KEY,
nombre varchar(25) NOT NULL,
apellido varchar(25) NOT NULL
)ENGINE = InnoDB;
insert into empleado values("1","María","Hernandez");

CREATE TABLE Usuario(
pkId VARCHAR(15) PRIMARY KEY,
fkIdEmpleado varchar(15) NOT NULL, 
nombre VARCHAR(30) NOT NULL,
contraseña VARCHAR(100) NOT NULL,
estado VARCHAR(1) NOT NULL,
intento INT NULL,

FOREIGN KEY (fkIdEmpleado) REFERENCES  Empleado(pkIdEmpleado)
)ENGINE = InnoDB;
INSERT INTO usuario(pkId,fkIdEmpleado, nombre, contraseña,estado,intento) VALUES ("1", "1", "admin","LKAekHU9EtweB49HAaTRfg==","1","0");
#usuario: admin
#contraseña: 12345

CREATE TABLE Modulo(
pkId VARCHAR(15) PRIMARY KEY,
nombre VARCHAR(30) NOT NULL,
descripcion VARCHAR(200) NOT NULL,
estado VARCHAR(1) NOT NULL
)ENGINE = InnoDB;
insert into modulo values ("1", "Seguridad", "Modulo de seguridad", 1);
insert into modulo values ("1001", "Hoteleria", "Modulo de hoteleria", 1);
insert into modulo values ("2001", "Compras", "Modulo de Compras", 1);
insert into modulo values ("3001", "Ventas", "Modulo de Ventas", 1);
insert into modulo values ("40001", "Inventarios", "Modulo de Inventarios", 1);
insert into modulo values ("50001", "RRHH", "Modulo de RRHH", 1);
insert into modulo values ("60001", "Bancos", "Modulo de Bancos", 1);
insert into modulo values ("70001", "Contabilidad", "Modulo de Contabilidad", 1);

CREATE TABLE Aplicacion(
pkId VARCHAR(15) PRIMARY KEY,
fkIdModulo VARCHAR(15) NOT NULL,
nombre VARCHAR(45) NULL,
estado INT NOT NULL,
rutaChm varchar(80) not null,
rutaHtml varchar(80) not null,
FOREIGN KEY (fkIdModulo) REFERENCES Modulo(pkId)
)ENGINE = InnoDB;

INSERT INTO aplicacion VALUES ("1","1","Mantenimiento Aplicacion", "1", "1", "");
#INSERT INTO aplicacion VALUES ("2","1","Prueba2", "1", "1", "0");
/*
INSERT INTO aplicacion VALUES ("2","Registro de Usuario",1,"");
INSERT INTO aplicacion VALUES ("3","Asignación de Perfiles a Usuario",1,"");
INSERT INTO aplicacion VALUES ("4","Permisos Usuario Aplicación",1,"");
*/
/*create table reporte (
	idReporte int NOT NULL primary key,
	nombre varchar(20) NOT NULL,
	ruta varchar(100) NOT NULL,
    idAplicacion VARCHAR(15) not null,
	estado char(1) NOT NULL,
    foreign key (idAplicacion) references aplicacion(pkId)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;*/


CREATE TABLE BitacoraUsuario(
pkId INT AUTO_INCREMENT PRIMARY KEY,
 `host` VARCHAR(45) NULL DEFAULT NULL,
ip VARCHAR(20) NULL,
conexionFecha DATE NULL,
conexionHora TIME NULL,
fkIdUsuario VARCHAR(15) NOT NULL,
fkIdAplicacion VARCHAR(15) NOT NULL,
accion VARCHAR(200) NOT NULL,

FOREIGN KEY (fkIdUsuario) REFERENCES Usuario (pkId),
FOREIGN KEY (fkIdAplicacion) REFERENCES Aplicacion(pkID)
)ENGINE = InnoDB;

CREATE TABLE Perfil(
pkId VARCHAR(15) PRIMARY KEY,
nombre VARCHAR(45) NULL,
estado VARCHAR(45) NULL
)ENGINE = InnoDB;

insert into perfil values("1","Administrador","1");
insert into perfil values("2","Vendedor","1");

CREATE TABLE UsuarioPerfil(
fkIdUsuario VARCHAR(15) NOT NULL,
fkIdPerfil VARCHAR(15) NOT NULL,

FOREIGN KEY (fkIdPerfil) REFERENCES Perfil (pkId),
FOREIGN KEY (fkIdUsuario) REFERENCES Usuario (pkId)
)ENGINE = InnoDB;

CREATE TABLE UsuarioAplicacion(
fkIdUsuario VARCHAR(15) NOT NULL,
fkIdAplicacion VARCHAR(15) NOT NULL,
permisoEscritura int,
permisoLectura int,
permisoModificar int,
permisoEliminar int,
permisoImprimir int,

FOREIGN KEY (fkIdAplicacion) REFERENCES Aplicacion (pkId),
FOREIGN KEY (fkIdUsuario) REFERENCES Usuario (pkId)
)ENGINE = InnoDB;

#insert into usuarioaplicacion VALUES (1,1,null,null,null,null,null);      

CREATE TABLE IF NOT EXISTS AplicacionPerfil (
fkIdPerfil VARCHAR(15) NOT NULL,
fkIdAplicacion VARCHAR(15) NOT NULL,
permisoEscritura int,
permisoLectura int,
permisoModificar int,
permisoEliminar int,
permisoImprimir int,

FOREIGN KEY (fkIdAplicacion) REFERENCES Aplicacion (pkId),
FOREIGN KEY (fkIdPerfil) REFERENCES Perfil (pkId)
)ENGINE = InnoDB;

/*insert into aplicacionperfil VALUES (1,1,null,null,null,null,null);
insert into aplicacionperfil VALUES (2,1,1,1,1,1,1);
insert into aplicacionperfil VALUES (1,2,1,1,1,1,1);*/

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `componenteseguridad`.`vwpermisosperfil` AS
    SELECT 
        `a`.`permisoEscritura` AS `permisoEscritura`,
        `a`.`permisoLectura` AS `permisoLectura`,
        `a`.`permisoModificar` AS `permisoModificar`,
        `a`.`permisoEliminar` AS `permisoEliminar`,
        `a`.`permisoImprimir` AS `permisoImprimir`,
        `b`.`pkId` AS `pkIdPerfil`,
        `b`.`nombre` AS `Perfil`,
        `c`.`pkId` AS `pkIdAplicacion`,
        `c`.`nombre` AS `Aplicacion`
    FROM
        ((`componenteseguridad`.`aplicacionperfil` `a`
        JOIN `componenteseguridad`.`perfil` `b` ON ((`b`.`pkId` = `a`.`fkIdPerfil`)))
        JOIN `componenteseguridad`.`aplicacion` `c` ON ((`c`.`pkId` = `a`.`fkIdAplicacion`)))
    ORDER BY `a`.`fkIdPerfil`;

select * from vwpermisosperfil;

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `componenteseguridad`.`vwpermisosusuario` AS
    SELECT 
        `a`.`permisoEscritura` AS `permisoEscritura`,
        `a`.`permisoLectura` AS `permisoLectura`,
        `a`.`permisoModificar` AS `permisoModificar`,
        `a`.`permisoEliminar` AS `permisoEliminar`,
        `a`.`permisoImprimir` AS `permisoImprimir`,
        `b`.`pkId` AS `pkIdUsuario`,
        `b`.`nombre` AS `Usuario`,
        `c`.`pkId` AS `pkIdAplicacion`,
        `c`.`nombre` AS `Aplicacion`
    FROM
        ((`componenteseguridad`.`usuarioaplicacion` `a`
        JOIN `componenteseguridad`.`usuario` `b` ON ((`b`.`pkId` = `a`.`fkIdUsuario`)))
        JOIN `componenteseguridad`.`aplicacion` `c` ON ((`c`.`pkId` = `a`.`fkIdAplicacion`)))
    ORDER BY `a`.`fkIdUsuario`;
    
    select * from vwpermisosusuario;
    
    CREATE TABLE UsuarioAplicacionAsignados(
fkIdUsuario VARCHAR(15) NOT NULL,
fkIdAplicacion VARCHAR(15) NOT NULL,

FOREIGN KEY (fkIdAplicacion) REFERENCES Aplicacion (pkId),
FOREIGN KEY (fkIdUsuario) REFERENCES Usuario (pkId)
)ENGINE = InnoDB;

