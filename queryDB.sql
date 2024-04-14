CREATE Database VeterinariaDB;

USE VeterinariaDB;

CREATE TABLE dbo.TVE_Clientes (
    TN_IdCliente INT IDENTITY (1, 1) PRIMARY KEY, TC_Nombre VARCHAR(60) NOT NULL, TC_Ap1 VARCHAR(60) NOT NULL, TC_Ap2 VARCHAR(60) NOT NULL, TC_NumTelefono VARCHAR(15) NOT NULL, TC_CorreoElectronico VARCHAR(100) NOT NULL
);

Create table dbo.TVET_Mascotas (
    TN_IdMascota INT IDENTITY (1, 1) PRIMARY KEY, TC_NombreMascota varchar(100) not null, TN_IdCliente int, Foreign key (TN_IdCliente) references dbo.TVE_Clientes (TN_IdCliente),
);

Create table dbo.TVET_DetalleMascota (
    TN_IdMascota int primary key, TC_Raza varchar(100) not null, TN_Peso decimal(18, 2) not null, TC_Color varchar(50) not null, Foreign key (Tn_IdMascota) references dbo.TVET_Mascotas (TN_IdMascota)
);

Create table dbo.TVET_Citas (
    TN_IdCita INT IDENTITY (1, 1) PRIMARY KEY, TN_IdCliente int, TN_IdMascota int, TF_FecCita datetime not null, Foreign key (TN_IdCliente) references dbo.TVE_Clientes (TN_IdCliente), Foreign key (Tn_IdMascota) references dbo.TVET_Mascotas (TN_IdMascota)
);

Create table dbo.TVET_Diagnostico (
    TN_IdDiagnostico int IDENTITY (1, 1) primary key, TN_IdCita int, TC_DscDiagnostico varchar(500) not null, Foreign key (TN_IdCita) references dbo.TVET_Citas (TN_IdCita)
);

DROP TABLE dbo.TVE_Clientes;
DROP TABLE dbo.TVET_Mascotas;
DROP TABLE dbo.TVET_DetalleMascota;
DROP TABLE dbo.TVET_Citas;
DROP TABLE dbo.TVET_Diagnostico;