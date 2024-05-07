USE master
GO

if DB_ID('DBUniversidad') is not null
	drop database DBUniversidad
go

create database DBUniversidad
go

use BDUniversidad
go

-- Crear la tablas de la base de datos
if OBJECT_ID('TEstudiante') is not null
	drop table TEstudiante
go
create table TEstudiante
(
	CodEstudiante char(5) primary key,
	Apellidos varchar(50) not null,
	Nombres varchar(50) not null
)
go

if OBJECT_ID('TAsignatura') is not null
	drop table TAsignatura
go
create table TAsignatura
(
	CodAsignatura char(5) primary key,
	Nombre varchar(50) not null,
	Creditos int 
)
go

if OBJECT_ID('TMatricula') is not null
	drop table TMatricula 
go
create table TMatricula
(
	CodEstudiante char(5),
	CodAsignatura char(5),
	Periodo varchar(50),
	Promedio int,
	primary key(CodEstudiante, CodAsignatura),
	foreign key(CodEstudiante) references TEstudiante,
	foreign key(CodAsignatura) references TAsignatura
)

insert into TEstudiante VALUES('E0001','Escobar','Ana')
insert into TEstudiante VALUES('E0002','Espirilla','Rosa')
insert into TEstudiante VALUES('E0003','Arizabal','Juan')
insert into TEstudiante VALUES('E0004','Estrada','Percy')
go

select * from TEstudiante
go