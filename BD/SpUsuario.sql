SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Usuario]

	@opc CHAR(10),
	@IdUsuario INT = 0,
	@Nombre VARCHAR(100) = NULL,
	@Cedula VARCHAR(20) = NULL

AS
BEGIN
DECLARE
@mensaje NVARCHAR(MAX),
@estado NVARCHAR(MAX)

IF @opc = 'LISTAR'
BEGIN
	SELECT IdUsuario, Nombre, Cedula FROM Usuario;
END

IF @opc = 'LISTAR_ID'
BEGIN
	SELECT IdUsuario, Nombre, Cedula FROM Usuario WHERE IdUsuario = @IdUsuario;
END

IF @opc = 'CREAR'
BEGIN
	INSERT INTO Usuario(Nombre, Cedula) VALUES(@Nombre, @Cedula);
	SET @mensaje = 'Registro creado Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ACTUALIZAR'
BEGIN
	UPDATE Usuario SET Nombre = @Nombre, Cedula = @Cedula WHERE IdUsuario = @IdUsuario;
	SET @mensaje = 'Registro actualizado Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ELIMINAR'
BEGIN
	DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;
	SET @mensaje = 'Registro eliminado Exitosamente';
	SET @estado = 'ok';
END

END
GO
