CREATE Database VeterinariaDB;

USE VeterinariaDB;

-- CREAR LAS TABLAS DE LA BASE DE DATOS --
CREATE TABLE dbo.TVE_Clientes (
    TN_IdCliente INT IDENTITY (1, 1) PRIMARY KEY, 
	TC_Nombre VARCHAR(60) NOT NULL, 
	TC_Ap1 VARCHAR(60) NOT NULL, 
	TC_Ap2 VARCHAR(60) NOT NULL, 
	TC_NumTelefono VARCHAR(15) NOT NULL, 
	TC_CorreoElectronico VARCHAR(100) NOT NULL
);

Create table dbo.TVET_Mascotas (
    TN_IdMascota INT IDENTITY (1, 1) PRIMARY KEY, 
	TC_NombreMascota varchar(100) not null, 
	TN_IdCliente int, Foreign key (TN_IdCliente) references dbo.TVE_Clientes (TN_IdCliente),
);

Create table dbo.TVET_DetalleMascota (
    TN_IdMascota int primary key, 
	TC_Raza varchar(100) not null, 
	TN_Peso decimal(18, 2) not null, 
	TC_Color varchar(50) not null, 
	Foreign key (Tn_IdMascota) references dbo.TVET_Mascotas (TN_IdMascota)
);

Create table dbo.TVET_Citas (
    TN_IdCita INT IDENTITY (1, 1) PRIMARY KEY, 
	TN_IdCliente int, TN_IdMascota int, 
	TF_FecCita datetime not null, 
	Foreign key (TN_IdCliente) references dbo.TVE_Clientes (TN_IdCliente), 
	Foreign key (Tn_IdMascota) references dbo.TVET_Mascotas (TN_IdMascota)
);

Create table dbo.TVET_Diagnostico (
    TN_IdDiagnostico int IDENTITY (1, 1) primary key, 
	TN_IdCita int, 
	TC_DscDiagnostico varchar(500) not null, 
	Foreign key (TN_IdCita) references dbo.TVET_Citas (TN_IdCita)
);

-- ELIMINAR TABLAS ---
DROP TABLE dbo.TVE_Clientes;
DROP TABLE dbo.TVET_Mascotas;
DROP TABLE dbo.TVET_DetalleMascota;
DROP TABLE dbo.TVET_Citas;
DROP TABLE dbo.TVET_Diagnostico;

-- PROCEDIMIENTOS ALMACENADOS PARA ELIMINAR ---

CREATE PROCEDURE spEliminarCitaYDiagnostico
@IdCita INT
AS
BEGIN
    -- Eliminar el diagnóstico asociado a la cita
    DELETE FROM dbo.TVET_Diagnostico
    WHERE TN_IdCita = @IdCita

    -- Eliminar la cita
    DELETE FROM dbo.TVET_Citas
    WHERE TN_IdCita = @IdCita
END;

CREATE PROCEDURE spEliminarClienteYRelacionados
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete records from TVET_Diagnostico related to the client's appointments
        DELETE FROM dbo.TVET_Diagnostico
        WHERE TN_IdCita IN (SELECT TN_IdCita
                            FROM dbo.TVET_Citas
                            WHERE TN_IdCliente = @IdCliente);

        -- Delete records from TVET_Citas related to the client's appointments
        DELETE FROM dbo.TVET_Citas
        WHERE TN_IdCliente = @IdCliente;

        -- Delete records from TVET_DetalleMascota related to the client's pets
        DELETE FROM dbo.TVET_DetalleMascota
        WHERE TN_IdMascota IN (SELECT TN_IdMascota
                                FROM dbo.TVET_Mascotas
                                WHERE TN_IdCliente = @IdCliente);

        -- Delete records from TVET_Mascotas related to the client
        DELETE FROM dbo.TVET_Mascotas
        WHERE TN_IdCliente = @IdCliente;

        -- Delete the client
        DELETE FROM dbo.TVE_Clientes
        WHERE TN_IdCliente = @IdCliente;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Forward the error to the caller
        THROW;
    END CATCH;
END;

Drop procedure spEliminarClienteYRelacionados;


CREATE PROCEDURE spEliminarMascotaYDetalles
    @IdMascota INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Eliminar registros de la tabla TVET_DetalleMascota relacionados con la mascota
        DELETE FROM dbo.TVET_DetalleMascota
        WHERE TN_IdMascota = @IdMascota;

        -- Eliminar la mascota
        DELETE FROM dbo.TVET_Mascotas
        WHERE TN_IdMascota = @IdMascota;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
    END CATCH;
END;

Drop procedure spEliminarMascotaYDetalles;

-- PROBAR PROCEDIMEINTOS ALMACENDAOS --
Select * from dbo.TVE_Clientes;
EXEC spEliminarClienteYRelacionados @IdCliente = 1010;

INSERT INTO dbo.TVET_DetalleMascota (TN_IdMascota, TC_Raza, TN_Peso, TC_Color)
VALUES (35, 'Labrador Retriever', 25.5, 'Negro');
Select * from dbo.TVET_Mascotas;
Select * from dbo.TVET_DetalleMascota;

EXEC spEliminarMascotaYDetalles @IdMascota = 35;


Select * from dbo.TVET_Citas;
Select * from dbo.TVET_Diagnostico;
EXEC spEliminarCitaYDiagnostico @IdCita = 43;


-- INSERTS DE PRUEBA --
INSERT INTO dbo.TVE_Clientes (TC_Nombre, TC_Ap1, TC_Ap2, TC_NumTelefono, TC_CorreoElectronico) 
VALUES ('Juan', 'González', 'López', '555-1234', 'juan@example.com');

INSERT INTO dbo.TVE_Clientes (TC_Nombre, TC_Ap1, TC_Ap2, TC_NumTelefono, TC_CorreoElectronico) 
VALUES ('María', 'Rodríguez', 'Sánchez', '555-5678', 'maria@example.com');

INSERT INTO dbo.TVET_Mascotas (TC_NombreMascota, TN_IdCliente)
VALUES ('Toby', 1018); 

INSERT INTO dbo.TVET_Mascotas (TC_NombreMascota, TN_IdCliente)
VALUES ('Luna', 1015); 

INSERT INTO dbo.TVET_Citas (TN_IdCliente, TN_IdMascota, TF_FecCita)
VALUES (1018, 43, '2024-04-15 10:00:00'); 

INSERT INTO dbo.TVET_Citas (TN_IdCliente, TN_IdMascota, TF_FecCita)
VALUES (1, 35, '2024-04-16 11:00:00'); 

INSERT INTO dbo.TVET_Diagnostico (TN_IdCita, TC_DscDiagnostico)
VALUES (54, 'Toby tiene fiebre y necesita tratamiento.'); 

INSERT INTO dbo.TVET_Diagnostico (TN_IdCita, TC_DscDiagnostico)
VALUES (53, 'Luna está sana y solo necesita un chequeo de rutina.'); 
