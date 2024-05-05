SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_TareaAsignada]
	@opc CHAR(10),
	@IdTarea INT = 0,
	@IdUsuario INT = 0,
	@IdTicket INT = 0,
	--@Fecha DATETIME,
	@IdEstado INT = 0

AS
BEGIN
DECLARE
@mensaje NVARCHAR(MAX),
@estado NVARCHAR(MAX)

IF @opc = 'LISTAR'
BEGIN
	SELECT IdTarea, IdUsuario, IdTicket, Fecha, IdEstado FROM TareaAsignada;
END

IF @opc = 'LISTAR_ID'
BEGIN
	SELECT IdTarea, IdUsuario, IdTicket, Fecha, IdEstado FROM TareaAsignada WHERE IdTarea = @IdTarea;
END

IF @opc = 'CREAR'
BEGIN
	INSERT INTO TareaAsignada(IdUsuario, IdTicket, Fecha, IdEstado) VALUES(@IdUsuario, @IdTicket, GETDATE(), @IdEstado);
	SET @mensaje = 'Tarea asignada Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ACTUALIZAR'
BEGIN
	UPDATE TareaAsignada SET IdUsuario = @IdUsuario, IdTicket = @IdTicket, Fecha = GETDATE(), IdEstado = @IdEstado WHERE IdTarea = @IdTarea;
	SET @mensaje = 'Tarea actualizada Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ELIMINAR'
BEGIN
	DELETE FROM TareaAsignada WHERE IdTarea = @IdTarea;
	SET @mensaje = 'Tarea eliminada Exitosamente';
	SET @estado = 'ok';
END

	SET NOCOUNT ON;


END
GO
