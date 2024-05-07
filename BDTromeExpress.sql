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
        IdCliente INT PRIMARY KEY IDENTITY(1,1),
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
        IdServicio INT PRIMARY KEY IDENTITY(1,1),
        Descripcion VARCHAR(200) NOT NULL,
        Tarifa DECIMAL(10, 2) NOT NULL
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TVehiculo', 'U') IS NULL
BEGIN
    -- Tabla de Veh�culos
    CREATE TABLE TVehiculo (
        IdVehiculo INT PRIMARY KEY IDENTITY(1,1),
        Marca VARCHAR(100) NOT NULL,
        Modelo VARCHAR(100) NOT NULL,
        Placa VARCHAR(20) NOT NULL,
        CapacidadCarga DECIMAL(10, 2) NOT NULL
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TEnvio', 'U') IS NULL
BEGIN
    -- Tabla de Env�os
    CREATE TABLE TEnvio (
        IdEnvio INT PRIMARY KEY IDENTITY(1,1),
        IdCliente INT NOT NULL,
        IdServicio INT NOT NULL,
        FechaEnvio DATE NOT NULL,
        FechaRecojo DATE NOT NULL,
        MontoPago DECIMAL(10, 2) NOT NULL,
        FOREIGN KEY (IdCliente) REFERENCES TCliente(IdCliente),
        FOREIGN KEY (IdServicio) REFERENCES TServicio(IdServicio)
    );
END

-- Verificamos si la tabla ya existe antes de crearla
IF OBJECT_ID('dbo.TColaborador', 'U') IS NULL
BEGIN
    -- Tabla de Colaboradores
    CREATE TABLE TColaborador (
        IdColaborador INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Cargo VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        Email VARCHAR(100),
        IdVehiculo INT,
        FOREIGN KEY (IdVehiculo) REFERENCES TVehiculo(IdVehiculo)
    );
END

-- Relaci�n entre Colaboradores y Env�os (muchos a muchos)
CREATE TABLE ColaboradorEnvio (
    IdColaborador INT,
    IdEnvio INT,
    PRIMARY KEY (IdColaborador, IdEnvio),
    FOREIGN KEY (IdColaborador) REFERENCES TColaborador(IdColaborador),
    FOREIGN KEY (IdEnvio) REFERENCES TEnvio(IdEnvio)
);

-- Inserci�n de datos de clientes
INSERT INTO TCliente (Nombre, Direccion, Telefono, Email)
VALUES 
    ('Cliente 1', 'Direcci�n Cliente 1', '123456789', 'cliente1@example.com'),
    ('Cliente 2', 'Direcci�n Cliente 2', '987654321', 'cliente2@example.com'),
    ('Cliente 3', 'Direcci�n Cliente 3', '555444333', 'cliente3@example.com');

-- Inserci�n de datos de servicios
INSERT INTO TServicio (Descripcion, Tarifa)
VALUES 
    ('Env�o est�ndar', 100.00),
    ('Env�o urgente', 150.00),
    ('Env�o con seguro', 200.00);

-- Inserci�n de datos de veh�culos
INSERT INTO TVehiculo (Marca, Modelo, Placa, CapacidadCarga)
VALUES 
    ('Toyota', 'Hilux', 'ABC123', 1500.00),
    ('Ford', 'Transit', 'XYZ789', 2000.00),
    ('Chevrolet', 'N300', 'DEF456', 1000.00);

-- Inserci�n de datos de env�os
INSERT INTO TEnvio (IdCliente, IdServicio, FechaEnvio, FechaRecojo, MontoPago)
VALUES 
    (1, 1, '2024-05-07', '2024-05-10', 150.00),
    (2, 2, '2024-05-08', '2024-05-11', 200.00),
    (3, 3, '2024-05-09', '2024-05-12', 180.00);

-- Inserci�n de datos en la tabla TColaborador
INSERT INTO TColaborador (Nombre, Cargo, Telefono, Email, IdVehiculo)
VALUES 
    ('Juan Perez', 'Gerente de Log�stica', '123456789', 'juan.perez@example.com', 1),
    ('Mar�a Lopez', 'Conductor', '987654321', 'maria.lopez@example.com', 2),
    ('Pedro Ramirez', 'Almacenista', '555444333', 'pedro.ramirez@example.com', 3);
