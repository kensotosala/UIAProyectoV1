Use VeterinariaDB;

CREATE PROCEDURE spEliminarClienteYRelacionados
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Disable the foreign key constraint temporarily
        ALTER TABLE dbo.TVET_Citas
        NOCHECK CONSTRAINT FK__TVET_Cita__TN_Id__5D60DB10;

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

        -- Re-enable the foreign key constraint
        ALTER TABLE dbo.TVET_Citas
        CHECK CONSTRAINT FK__TVET_Cita__TN_Id__5D60DB10;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Forward the error to the caller
        THROW;
    END CATCH;
END;


-- CITA Y DIAGNÓSTICO --
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


-- MASCOTAS Y DEMÁS --
CREATE PROCEDURE spEliminarMascotaYDetalles
    @IdMascota INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Eliminar registros de la tabla TVET_Diagnostico relacionados con las citas de la mascota
        DELETE FROM dbo.TVET_Diagnostico
        WHERE TN_IdCita IN (
            SELECT TN_IdCita
            FROM dbo.TVET_Citas
            WHERE TN_IdMascota = @IdMascota
        );

        -- Eliminar registros de la tabla TVET_Citas relacionados con la mascota
        DELETE FROM dbo.TVET_Citas
        WHERE TN_IdMascota = @IdMascota;

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
        
        THROW;
    END CATCH;
END;
