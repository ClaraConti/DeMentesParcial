-- Eliminamos la base de datos si existe
IF DB_ID('BDTrome') IS NOT NULL
   DROP DATABASE BDTrome;
GO

-- Creamos la base de datos BDTrome
CREATE DATABASE BDTrome;
GO

-- Usamos la base de datos BDTrome
USE BDTrome;
GO

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TCliente', 'U') IS NULL
BEGIN
    -- Tabla de Clientes
    CREATE TABLE TCliente (
        IdCliente INT PRIMARY KEY ,
        Nombre VARCHAR(100) NOT NULL,
        Direccion VARCHAR(200) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        Email VARCHAR(100)
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TServicio', 'U') IS NULL
BEGIN
    -- Tabla de Servicios
    CREATE TABLE TServicio (
        IdServicio INT PRIMARY KEY ,
        Descripcion VARCHAR(200) NOT NULL,
        Tarifa DECIMAL(10, 2) NOT NULL
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TVehiculo', 'U') IS NULL
BEGIN
    -- Tabla de Vehículos
    CREATE TABLE TVehiculo (
        IdVehiculo INT PRIMARY KEY ,
        Marca VARCHAR(100) NOT NULL,
        Modelo VARCHAR(100) NOT NULL,
        Placa VARCHAR(20) NOT NULL,
        CapacidadCarga DECIMAL(10, 2) NOT NULL
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TEnvio', 'U') IS NULL
BEGIN
    -- Tabla de Envíos
    CREATE TABLE TEnvio (
        IdEnvio INT PRIMARY KEY ,
        IdCliente INT NOT NULL,
        IdServicio INT NOT NULL,
        FechaEnvio DATE NOT NULL,
        FechaRecojo DATE NOT NULL,
        MontoPago DECIMAL(10, 2) NOT NULL,
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TColaborador', 'U') IS NULL
BEGIN
    -- Tabla de Colaboradores
    CREATE TABLE TColaborador (
        IdColaborador INT PRIMARY KEY ,
        Nombre VARCHAR(100) NOT NULL,
        Cargo VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        Email VARCHAR(100),
        IdVehiculos INT,
    );
END

-- Relación entre Colaboradores y Envíos (muchos a muchos)
CREATE TABLE ColaboradorEnvio (
    IdColaborador INT,
    IdEnvio INT,
    PRIMARY KEY (IdColaborador, IdEnvio),
    FOREIGN KEY (IdColaborador) REFERENCES TColaborador(IdColaborador),
    FOREIGN KEY (IdEnvio) REFERENCES TEnvio(IdEnvio)
);

-- Inserción de datos de clientes
INSERT INTO TCliente (IdCliente,Nombre, Direccion, Telefono, Email)
VALUES 
    (1,'Cliente 1', 'Dirección Cliente 1', '123456789', 'cliente1@example.com'),
    (2,'Cliente 2', 'Dirección Cliente 2', '987654321', 'cliente2@example.com'),
    (3,'Cliente 3', 'Dirección Cliente 3', '555444333', 'cliente3@example.com');

-- Inserción de datos de servicios
INSERT INTO TServicio (IdServicio,Descripcion, Tarifa)
VALUES 
    (1,'Envío estándar', 100.00),
    (2,'Envío urgente', 150.00),
    (3,'Envío con seguro', 200.00);

-- Inserción de datos de vehículos
INSERT INTO TVehiculo (IdVehiculo,Marca, Modelo, Placa, CapacidadCarga)
VALUES 
    (1,'Toyota', 'Hilux', 'ABC123', 1500.00),
    (2,'Ford', 'Transit', 'XYZ789', 2000.00),
    (3,'Chevrolet', 'N300', 'DEF456', 1000.00);

-- Inserción de datos de envíos
INSERT INTO TEnvio (IdEnvio,IdCliente, IdServicio, FechaEnvio, FechaRecojo, MontoPago)
VALUES 
    (1,1, 1, '2024-05-07', '2024-05-10', 150.00),
    (2,2, 2, '2024-05-08', '2024-05-11', 200.00),
    (3,3, 3, '2024-05-09', '2024-05-12', 180.00);

-- Inserción de datos en la tabla TColaborador
INSERT INTO TColaborador (IdColaborador,Nombre, Cargo, Telefono, Email, IdVehiculos)
VALUES 
    (1,'Juan Perez', 'Gerente de Logística', '123456789', 'juan.perez@example.com', 1),
    (2,'María Lopez', 'Conductor', '987654321', 'maria.lopez@example.com', 2),
    (3,'Pedro Ramirez', 'Almacenista', '555444333', 'pedro.ramirez@example.com', 3);


	select * from TCliente

go	
select * from TServicio 
go	
select * from TVehiculo
go
select * from TEnvio 
go
select * from TColaborador
go