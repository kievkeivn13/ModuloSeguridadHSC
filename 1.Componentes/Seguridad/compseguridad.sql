
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

CREATE TABLE Aplicacion(
pkId VARCHAR(15) PRIMARY KEY,
fkIdModulo VARCHAR(15) NOT NULL,
nombre VARCHAR(45) NULL,
estado INT NOT NULL,
rutaChm varchar(80) not null,
rutaHtml varchar(80) not null,
FOREIGN KEY (fkIdModulo) REFERENCES Modulo(pkId)
)ENGINE = InnoDB;

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
fkIdUsuario VARCHAR(15) NOT NULL,
 `host` VARCHAR(45) NULL DEFAULT NULL,
ip VARCHAR(20) NULL,
fkIdModulo VARCHAR(15) NOT NULL,
fkIdAplicacion VARCHAR(15) NOT NULL,
accion VARCHAR(200) NOT NULL,
conexionFecha DATE NULL,
conexionHora TIME NULL,
  
FOREIGN KEY (fkIdUsuario) REFERENCES Usuario (pkId),
FOREIGN KEY (fkIdModulo) REFERENCES Modulo (pkId),
FOREIGN KEY (fkIdAplicacion) REFERENCES Aplicacion(pkID)
)ENGINE = InnoDB;

CREATE TABLE Perfil(
pkId VARCHAR(15) PRIMARY KEY,
nombre VARCHAR(45) NULL,
estado VARCHAR(45) NULL
)ENGINE = InnoDB;

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

insert into perfil values("1","Administrador","1");
insert into perfil values("2","Vendedor","1");

INSERT INTO modulo VALUES ('1','Seguridad','Módulo de Seguridad',1);

INSERT INTO aplicacion VALUES ("0001","1","Login Seguridad HSC",1,0001,0);
INSERT INTO aplicacion VALUES ("0002","1","Registrar Usuario",1,0002,0);
INSERT INTO aplicacion VALUES ("0003","1","Mantenimiento Aplicación",1,0003,0);
INSERT INTO aplicacion VALUES ("0004","1","Mantenimiento Perfil",1,0004,0);
INSERT INTO aplicacion VALUES ("0005","1","Asignación de Aplicación a Perfiles",1,0005,0);
INSERT INTO aplicacion VALUES ("0006","1","Asignación de Aplicación a Usuarios",1,0006,0);
INSERT INTO aplicacion VALUES ("0007","1","Asignación de Perfiles a Usuarios",1,0007,0);
INSERT INTO aplicacion VALUES ("0008","1","Asignación Permisos",1,0008,0);
INSERT INTO aplicacion VALUES ("0009","1","Recuperar Contraseña",1,0009,0);
INSERT INTO aplicacion VALUES ("0010","1","Cambiar Contraseña",1,0010,0);
INSERT INTO aplicacion VALUES ("0011","1","Consulta Bitácora",1,0011,0);


