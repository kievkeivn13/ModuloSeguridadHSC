-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema componenteseguridad
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `componenteseguridad` ;

-- -----------------------------------------------------
-- Schema componenteseguridad
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `componenteseguridad` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `componenteseguridad` ;

-- -----------------------------------------------------
-- Table `componenteseguridad`.`aplicacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`aplicacion` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`aplicacion` (
  `pkId` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `estado` INT NOT NULL,
  `idReporteAsociado` VARCHAR(15) NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`perfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`perfil` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`perfil` (
  `pkId` VARCHAR(15) NOT NULL,
  `fkIdTipoUsuario` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`aplicacionperfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`aplicacionperfil` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`aplicacionperfil` (
  `fkIdPerfil` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  `permisoEscritura` INT NOT NULL,
  `permisoLectura` INT NOT NULL,
  `permisoModificar` INT NOT NULL,
  `permisoEliminar` INT NOT NULL,
  `permisoImprimir` INT NOT NULL,
  PRIMARY KEY (`fkIdPerfil`),
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  CONSTRAINT `aplicacionperfil_ibfk_1`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `componenteseguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `aplicacionperfil_ibfk_2`
    FOREIGN KEY (`fkIdPerfil`)
    REFERENCES `componenteseguridad`.`perfil` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`empleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`empleado` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`empleado` (
  `pkIdEmpleado` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(25) NOT NULL,
  `apellido` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`pkIdEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`usuario` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`usuario` (
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
    REFERENCES `componenteseguridad`.`empleado` (`pkIdEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`bitacorausuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`bitacorausuario` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`bitacorausuario` (
  `pkId` INT NOT NULL AUTO_INCREMENT,
  `host` VARCHAR(45) NULL DEFAULT NULL,
  `ip` VARCHAR(20) NULL DEFAULT NULL,
  `conexionFecha` DATE NULL DEFAULT NULL,
  `conexionHora` TIME NULL DEFAULT NULL,
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`pkId`),
  INDEX `fkIdUsuario` (`fkIdUsuario` ASC) VISIBLE,
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  CONSTRAINT `bitacorausuario_ibfk_1`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `componenteseguridad`.`usuario` (`pkId`),
  CONSTRAINT `bitacorausuario_ibfk_2`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `componenteseguridad`.`aplicacion` (`pkId`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`usuarioaplicacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`usuarioaplicacion` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`usuarioaplicacion` (
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdAplicacion` VARCHAR(15) NOT NULL,
  `permisoEscritura` INT NOT NULL,
  `permisoLectura` INT NOT NULL,
  `permisoModificar` INT NOT NULL,
  `permisoEliminar` INT NOT NULL,
  `permisoImprimir` INT NOT NULL,
  PRIMARY KEY (`fkIdUsuario`),
  INDEX `fkIdAplicacion` (`fkIdAplicacion` ASC) VISIBLE,
  CONSTRAINT `usuarioaplicacion_ibfk_1`
    FOREIGN KEY (`fkIdAplicacion`)
    REFERENCES `componenteseguridad`.`aplicacion` (`pkId`),
  CONSTRAINT `usuarioaplicacion_ibfk_2`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `componenteseguridad`.`usuario` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `componenteseguridad`.`usuarioperfil`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `componenteseguridad`.`usuarioperfil` ;

CREATE TABLE IF NOT EXISTS `componenteseguridad`.`usuarioperfil` (
  `fkIdUsuario` VARCHAR(15) NOT NULL,
  `fkIdPerfil` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`fkIdUsuario`),
  INDEX `fkIdPerfil` (`fkIdPerfil` ASC) VISIBLE,
  CONSTRAINT `usuarioperfil_ibfk_1`
    FOREIGN KEY (`fkIdPerfil`)
    REFERENCES `componenteseguridad`.`perfil` (`pkId`),
  CONSTRAINT `usuarioperfil_ibfk_2`
    FOREIGN KEY (`fkIdUsuario`)
    REFERENCES `componenteseguridad`.`usuario` (`pkId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
