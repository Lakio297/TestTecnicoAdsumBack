 
 CREATE DATABASE /ContactosDB;

USE ContactosDB;

CREATE TABLE Contacts (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(100),
    NombreEmpresa NVARCHAR(100),
    CorreoElectronico NVARCHAR(100),
    Telefono NVARCHAR(20),
    Categoria NVARCHAR(20),
    Mensaje NVARCHAR(MAX)
);