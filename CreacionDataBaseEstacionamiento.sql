CREATE DATABASE ESTACIONAMIENTO

USE ESTACIONAMIENTO

CREATE TABLE USUARIO(
ID_USUARIO INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
NOMBRE VARCHAR(50) NOT NULL,
NOMBRE_USUARIO VARCHAR(50) NOT NULL, 
CONTRASENIA VARCHAR(20) NOT NULL)

CREATE TABLE VEHICULO(
PATENTE VARCHAR (8) PRIMARY KEY NOT NULL,
MARCA VARCHAR(50) NOT NULL,
MODELO VARCHAR(50) NOT NULL
)

CREATE TABLE INGRESO(
ID_INGRESO INT IDENTITY (1000,1) PRIMARY KEY NOT NULL,
FECHA_ENTRADA DATE NOT NULL,
HORA_ENTRADA TIME NOT NULL,
ESTADO VARCHAR(20) NOT NULL,
PATENTE_VEHICULO VARCHAR(8) NOT NULL
)

CREATE TABLE SALIDA(
ID_SALIDA INT IDENTITY (1000,1) PRIMARY KEY NOT NULL,
FECHA_SALIDA DATE NOT NULL,
HORA_SALIDA TIME NOT NULL,
PATENTE_VEHICULO VARCHAR(8) NOT NULL
)

ALTER TABLE INGRESO
ADD CONSTRAINT FK_INGRESO
FOREIGN KEY (PATENTE_VEHICULO) REFERENCES VEHICULO(PATENTE)

ALTER TABLE SALIDA
ADD CONSTRAINT FK_SALIDA
FOREIGN KEY (PATENTE_VEHICULO) REFERENCES VEHICULO(PATENTE)

CREATE TABLE BOLETA(
ID_BOLETA INT IDENTITY (1000,1) PRIMARY KEY NOT NULL,
ID_INGRESO INT NOT NULL,
ID_SALIDA INT NOT NULL,
TOTAL_A_PAGAR INT NOT NULL
)

ALTER TABLE BOLETA
ADD CONSTRAINT FK_BOLETA1
FOREIGN KEY (ID_INGRESO) REFERENCES INGRESO(ID_INGRESO)

ALTER TABLE BOLETA
ADD CONSTRAINT FK_BOLETA2
FOREIGN KEY (ID_SALIDA) REFERENCES SALIDA(ID_SALIDA)
