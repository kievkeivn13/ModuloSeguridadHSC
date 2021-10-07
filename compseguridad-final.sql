-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ComponenteSeguridad
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `ComponenteSeguridad` ;

-- -----------------------------------------------------
-- Schema ComponenteSeguridad
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ComponenteSeguridad` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `ComponenteSeguridad` ;

-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`modulo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`modulo` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`modulo` (
  `pkId` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(30) NOT NULL,
  `descripcion` VARCHAR(200) NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`aplicacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`aplicacion` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`aplicacion` (
  `pkId` VARCHAR(15) NOT NULL,
  `fkIdModulo` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `estado` INT NOT NULL,
  `idReporteAsociado` VARCHAR(15) NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`),
  INDEX `fkIdModulo` (`fkIdModulo` ASC) VISIBLE,
  CONSTRAINT `aplicacion_ibfk_1`
    FOREIGN KEY (`fkIdModulo`)
    REFERENCES `ComponenteSeguridad`.`modulo` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`perfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`perfil` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`perfil` (
  `pkId` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`aplicacionperfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`aplicacionperfil` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`aplicacionperfil` (
  `fkIdPerfil` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  `permisoEscritura` INT NULL DEFAULT NULL,
  `permisoLectura` INT NULL DEFAULT NULL,
  `permisoModificar` INT NULL DEFAULT NULL,
  `permisoEliminar` INT NULL DEFAULT NULL,
  `permisoImprimir` INT NULL DEFAULT NULL,
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  INDEX `fkIdPerfil` (`fkIdPerfil` ASC) VISIBLE,
  CONSTRAINT `aplicacionperfil_ibfk_1`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `ComponenteSeguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `aplicacionperfil_ibfk_2`
    FOREIGN KEY (`fkIdPerfil`)
    REFERENCES `ComponenteSeguridad`.`perfil` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`empleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`empleado` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`empleado` (
  `pkIdEmpleado` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(25) NOT NULL,
  `apellido` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`pkIdEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`usuario` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`usuario` (
  `pkId` VARCHAR(15) NOT NULL,
  `fkIdEmpleado` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(30) NOT NULL,
  `contraseña` VARCHAR(100) NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  `intento` INT NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`),
  INDEX `fkIdEmpleado` (`fkIdEmpleado` ASC) VISIBLE,
  CONSTRAINT `usuario_ibfk_1`
    FOREIGN KEY (`fkIdEmpleado`)
    REFERENCES `ComponenteSeguridad`.`empleado` (`pkIdEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`bitacorausuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`bitacorausuario` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`bitacorausuario` (
  `pkId` INT NOT NULL AUTO_INCREMENT,
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `host` VARCHAR(45) NULL DEFAULT NULL,
  `ip` VARCHAR(20) NULL DEFAULT NULL,
  `fkIdModulo` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  `accion` VARCHAR(200) NULL DEFAULT NULL,
  `conexionFecha` DATE NULL DEFAULT NULL,
  `conexionHora` TIME NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`),
  INDEX `fkIdUsuario` (`fkIdUsuario` ASC) VISIBLE,
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  INDEX `fk_bitacorausuario_modulo1_idx` (`fkIdModulo` ASC) VISIBLE,
  CONSTRAINT `bitacorausuario_ibfk_1`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `ComponenteSeguridad`.`usuario` (`pkId`),
  CONSTRAINT `bitacorausuario_ibfk_2`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `ComponenteSeguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `fk_bitacorausuario_modulo1`
    FOREIGN KEY (`fkIdModulo`)
    REFERENCES `ComponenteSeguridad`.`modulo` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`usuarioaplicacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`usuarioaplicacion` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`usuarioaplicacion` (
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  `permisoEscritura` INT NULL DEFAULT NULL,
  `permisoLectura` INT NULL DEFAULT NULL,
  `permisoModificar` INT NULL DEFAULT NULL,
  `permisoEliminar` INT NULL DEFAULT NULL,
  `permisoImprimir` INT NULL DEFAULT NULL,
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  INDEX `fkIdUsuario` (`fkIdUsuario` ASC) VISIBLE,
  CONSTRAINT `usuarioaplicacion_ibfk_1`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `ComponenteSeguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `usuarioaplicacion_ibfk_2`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `ComponenteSeguridad`.`usuario` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`usuarioaplicacionasignados`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`usuarioaplicacionasignados` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`usuarioaplicacionasignados` (
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  INDEX `fkIdUsuario` (`fkIdUsuario` ASC) VISIBLE,
  CONSTRAINT `usuarioaplicacionasignados_ibfk_1`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `ComponenteSeguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `usuarioaplicacionasignados_ibfk_2`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `ComponenteSeguridad`.`usuario` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ComponenteSeguridad`.`usuarioperfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`usuarioperfil` ;

CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`usuarioperfil` (
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdPerfil` VARCHAR(15) NOT NULL,
  INDEX `fkIdPerfil` (`fkIdPerfil` ASC) VISIBLE,
  INDEX `fkIdUsuario` (`fkIdUsuario` ASC) VISIBLE,
  CONSTRAINT `usuarioperfil_ibfk_1`
    FOREIGN KEY (`fkIdPerfil`)
    REFERENCES `ComponenteSeguridad`.`perfil` (`pkId`),
  CONSTRAINT `usuarioperfil_ibfk_2`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `ComponenteSeguridad`.`usuario` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

USE `ComponenteSeguridad` ;

-- -----------------------------------------------------
-- Placeholder table for view `ComponenteSeguridad`.`vwpermisosperfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`vwpermisosperfil` (`permisoEscritura` INT, `permisoLectura` INT, `permisoModificar` INT, `permisoEliminar` INT, `permisoImprimir` INT, `pkIdPerfil` INT, `Perfil` INT, `pkIdAplicacion` INT, `Aplicacion` INT);

-- -----------------------------------------------------
-- Placeholder table for view `ComponenteSeguridad`.`vwpermisosusuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ComponenteSeguridad`.`vwpermisosusuario` (`permisoEscritura` INT, `permisoLectura` INT, `permisoModificar` INT, `permisoEliminar` INT, `permisoImprimir` INT, `pkIdUsuario` INT, `Usuario` INT, `pkIdAplicacion` INT, `Aplicacion` INT);

-- -----------------------------------------------------
-- View `ComponenteSeguridad`.`vwpermisosperfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`vwpermisosperfil`;
DROP VIEW IF EXISTS `ComponenteSeguridad`.`vwpermisosperfil` ;
USE `ComponenteSeguridad`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ComponenteSeguridad`.`vwpermisosperfil` AS select `a`.`permisoEscritura` AS `permisoEscritura`,`a`.`permisoLectura` AS `permisoLectura`,`a`.`permisoModificar` AS `permisoModificar`,`a`.`permisoEliminar` AS `permisoEliminar`,`a`.`permisoImprimir` AS `permisoImprimir`,`b`.`pkId` AS `pkIdPerfil`,`b`.`nombre` AS `Perfil`,`c`.`pkId` AS `pkIdAplicacion`,`c`.`nombre` AS `Aplicacion` from ((`ComponenteSeguridad`.`aplicacionperfil` `a` join `ComponenteSeguridad`.`perfil` `b` on((`b`.`pkId` = `a`.`fkIdPerfil`))) join `ComponenteSeguridad`.`aplicacion` `c` on((`c`.`pkId` = `a`.`fkIdAplicacion`))) order by `a`.`fkIdPerfil`;

-- -----------------------------------------------------
-- View `ComponenteSeguridad`.`vwpermisosusuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ComponenteSeguridad`.`vwpermisosusuario`;
DROP VIEW IF EXISTS `ComponenteSeguridad`.`vwpermisosusuario` ;
USE `ComponenteSeguridad`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ComponenteSeguridad`.`vwpermisosusuario` AS select `a`.`permisoEscritura` AS `permisoEscritura`,`a`.`permisoLectura` AS `permisoLectura`,`a`.`permisoModificar` AS `permisoModificar`,`a`.`permisoEliminar` AS `permisoEliminar`,`a`.`permisoImprimir` AS `permisoImprimir`,`b`.`pkId` AS `pkIdUsuario`,`b`.`nombre` AS `Usuario`,`c`.`pkId` AS `pkIdAplicacion`,`c`.`nombre` AS `Aplicacion` from ((`ComponenteSeguridad`.`usuarioaplicacion` `a` join `ComponenteSeguridad`.`usuario` `b` on((`b`.`pkId` = `a`.`fkIdUsuario`))) join `ComponenteSeguridad`.`aplicacion` `c` on((`c`.`pkId` = `a`.`fkIdAplicacion`))) order by `a`.`fkIdUsuario`;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

INSERT INTO `componenteseguridad`.`modulo`
(`pkId`,
`nombre`,
`descripcion`,
`estado`)
VALUES
('1',
'Recursos Humanos',
'Módulo de RH',
1);

INSERT INTO `componenteseguridad`.`modulo`
(`pkId`,
`nombre`,
`descripcion`,
`estado`)
VALUES
('2',
'Seguridad',
'Módulo de Seguridad',
1);

INSERT INTO `componenteseguridad`.`modulo`
(`pkId`,
`nombre`,
`descripcion`,
`estado`)
VALUES
('3',
'Ventas',
'Módulo de Ventas',
1);

INSERT INTO `componenteseguridad`.`aplicacion`
(`pkId`,
`fkIdModulo`,
`nombre`,
`estado`,
`idReporteAsociado`)
VALUES
("1",
"2",
"Iniciar Sesión",
1,
1);

INSERT INTO `componenteseguridad`.`aplicacion`
(`pkId`,
`fkIdModulo`,
`nombre`,
`estado`,
`idReporteAsociado`)
VALUES
("2",
"2",
"Registrar Usuario",
1,
1);


INSERT INTO `componenteseguridad`.`empleado`
(`pkIdEmpleado`,
`nombre`,
`apellido`)
VALUES
("1",
"María",
"Hernandez");

INSERT INTO `componenteseguridad`.`empleado`
(`pkIdEmpleado`,
`nombre`,
`apellido`)
VALUES
("2",
"Melanie",
"Revolorio");


