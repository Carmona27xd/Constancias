USE [master];
IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Certificade_GS')
BEGIN
    ALTER DATABASE Certificade_GS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Certificade_GS;
END;

CREATE DATABASE Certificade_GS;
GO
USE Certificade_GS;
GO

-- CREACIÓN DE TABLAS ---------------------------------------------------

CREATE TABLE EmployeeRole (
    IdEmployeeRole INT PRIMARY KEY IDENTITY(1,1),
    Role VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE EmployeeContractType (
    IdContractType INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE EmployeeProfesorCategory (
    IdProfesorCategory INT PRIMARY KEY IDENTITY(1,1),
    Category VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE Employee (
    IdEmployee INT PRIMARY KEY IDENTITY(1,1),
    Tuition VARCHAR(40) NOT NULL UNIQUE,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    IdRole INT NOT NULL,
    IdContractType INT NOT NULL,
    IdProfesorCategory INT NOT NULL,

    CONSTRAINT fk_Role_Employee FOREIGN KEY (IdRole) REFERENCES EmployeeRole(IdEmployeeRole),
    CONSTRAINT fk_ContractType_Employee FOREIGN KEY (IdContractType) REFERENCES EmployeeContractType(IdContractType),
    CONSTRAINT fk_ProfesorCategory_Employee FOREIGN KEY (IdProfesorCategory) REFERENCES EmployeeProfesorCategory(IdProfesorCategory)
);

CREATE TABLE CertificadeType (
    IdCertificadeType INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE Certificade (
    IdCertifcade INT PRIMARY KEY IDENTITY(1,1),
    Document VARBINARY(MAX),
    DateApplied DATE NOT NULL,
    IdCertifiedType INT NOT NULL,
    IdProfesor INT NOT NULL,

    CONSTRAINT fk_CertificadeType_Certificade FOREIGN KEY (IdCertifiedType) REFERENCES CertificadeType (IdCertificadeType),
    CONSTRAINT fk_Profesor_Certificade FOREIGN KEY (IdProfesor) REFERENCES Employee (IdEmployee)
);

-- INSERCIÓN DE DATOS CONSTANTES ---------------------------------------

INSERT INTO EmployeeRole (Role) 
            VALUES ('Administrador'), ('Administrativo'), ('Profesor');

INSERT INTO EmployeeContractType (Type) 
            VALUES ('Sin asignar'),     -- ID = 1
                   ('Tiempo completo'), -- ID = 2
                   ('Medio tiempo'),    -- ID = 3
                   ('Por asignatura'),  -- ID = 4
                   ('Temporal'),        -- ID = 5
                   ('Honorarios');      -- ID = 6

INSERT INTO EmployeeProfesorCategory (Category)
            VALUES ('Sin asignar'),     -- ID = 1
                   ('Titular'),         -- ID = 2
                   ('Asociado'),        -- ID = 3
                   ('Asistente'),       -- ID = 4
                   ('Adjunto'),         -- ID = 5
                   ('Sustituto');       -- ID = 6

-- INSERCIÓN DE EMPLEADOS ---------------------------------------------

INSERT INTO Employee (Tuition, FirstName, MiddleName, LastName, Email, Password, IdRole, IdContractType, IdProfesorCategory) 
            VALUES ('zA04012840',   'Ernesto',    'González',   'Pérez',    'administrador@example.com',    '1234', 1, 1, 1), 
                   ('zD19017267',   'Sheila',     'Muñóz',      'Arraiga',  'administrativo@example.com',   '1234', 2, 1, 1),
                   ('zP23097890',   'Erika',      'Meneses',    'Riko',     'profesor@example.com',         '1234', 3, 2, 2),
                   ('zP23097891',   'Karen',      'Cortes',     'Verdín',     'profesor2@example.com',      '1234', 3, 2, 2);

-- INSERCIÓN DE TIPOS DE CERTIFICADOS ---------------------------------

INSERT INTO CertificadeType (Type) 
            VALUES ('Participación en actualización de EE'),
                   ('Proceso de acreditación'), 
                   ('De dirección'),
                   ('De experiencia educativa'),
                   ('Jurado de exámen de oposición'),
                   ('Orbis Tertius');

-- INSERCIÓN DE CERTIFICADOS ---------------------------------
INSERT INTO Certificade (Document, DateApplied, IdCertifiedType, IdProfesor) 
            VALUES(NULL, '2024-11-25', 1, 1), (NULL, '2024-11-25', 1, 1);
SELECT crt.IdCertifcade, crtty.Type, CONCAT(empl.FirstName,' ',empl.MiddleName) AS ProfesorName, crt.DateApplied AS DateEmited
FROM Certificade crt
LEFT JOIN CertificadeType crtty ON crt.IdCertifiedType = crtty.IdCertificadeType
LEFT JOIN Employee empl ON crt.IdProfesor = empl.IdEmployee;