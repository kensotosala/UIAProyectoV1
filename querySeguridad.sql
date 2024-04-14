Create Database UsersVET;

Use UsersVET;

Create table TBUsuarios (
	IdUsuario int primary key identity(1,1) not null,
	Usuario varchar(75) not null,
	Contrasenha varchar(30) not null
);

Drop table TBUsuarios;

INSERT INTO TBUsuarios (Usuario, Contrasenha)
VALUES ('admin1', 'admin1');

INSERT INTO TBUsuarios (Usuario, Contrasenha)
VALUES ('admin2', 'admin2');

INSERT INTO TBUsuarios (Usuario, Contrasenha)
VALUES ('admin3', 'admin3');


Select * from TBUsuarios;

CREATE PROCEDURE SP_Login
    @Usuario VARCHAR(75),
    @Contrasenha VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID INT;

    SELECT @UserID = IdUsuario
    FROM TBUsuarios
    WHERE Usuario = @Usuario
      AND Contrasenha = @Contrasenha;

    IF @UserID IS NOT NULL
    BEGIN
        SELECT 'Login exitoso. Bienvenido.';
    END
    ELSE
    BEGIN
        SELECT 'Credenciales inválidas. Por favor, inténtelo de nuevo.';
    END
END;


Drop procedure SP_Login;

EXEC SP_Login 'admin2', 'admin2';

