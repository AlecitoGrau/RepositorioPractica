SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_EstadoTicket]
	@opc CHAR(10),
	@IdEstado INT = 0,
	@NombreEstado VARCHAR(20)

AS
BEGIN

IF @opc = 'LISTAR'
BEGIN
	SELECT IdEstado, NombreEstado FROM EstadoTicket;
END

	SET NOCOUNT ON;


END
GO
