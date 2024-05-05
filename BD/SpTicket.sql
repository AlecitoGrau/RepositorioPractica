SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Ticket]
	@opc CHAR(10),
	@IdTicket INT = 0,
	@Descripcion VARCHAR(500) = NULL,
	@Prioridad VARCHAR(10) = NULL

AS
BEGIN
DECLARE
@mensaje NVARCHAR(MAX),
@estado NVARCHAR(MAX)

IF @opc = 'LISTAR'
BEGIN
	SELECT IdTicket, Descripcion, Prioridad FROM Ticket;
END

IF @opc = 'LISTAR_ID'
BEGIN
	SELECT IdTicket, Descripcion, Prioridad FROM Ticket WHERE IdTicket = @IdTicket;
END

IF @opc = 'CREAR'
BEGIN
	INSERT INTO Ticket(Descripcion, Prioridad) VALUES(@Descripcion, @Prioridad);
	SET @mensaje = 'Ticket creado Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ACTUALIZAR'
BEGIN
	UPDATE Ticket SET Descripcion = @Descripcion, Prioridad = @Prioridad WHERE IdTicket = @IdTicket;
	SET @mensaje = 'Ticket actualizado Exitosamente';
	SET @estado = 'ok';
END

IF @opc = 'ELIMINAR'
BEGIN
	DELETE FROM Ticket WHERE IdTicket = @IdTicket;
	SET @mensaje = 'Ticket eliminado Exitosamente';
	SET @estado = 'ok';
END

	SET NOCOUNT ON;
END
GO
