CREATE DATABASE PruebaAsignacion

GO

USE PruebaAsignacion

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(100),
	Cedula VARCHAR(20)
);

GO

CREATE TABLE Ticket(
	IdTicket INT PRIMARY KEY IDENTITY(2,2),
	Descripcion VARCHAR(500),
	Prioridad VARCHAR(10)
);

GO

CREATE TABLE EstadoTicket(
	IdEstado INT PRIMARY KEY,
	NombreEstado VARCHAR(20)
);

GO

INSERT INTO EstadoTicket(IdEstado, NombreEstado) VALUES(1, 'En proceso');
INSERT INTO EstadoTicket(IdEstado, NombreEstado) VALUES(2, 'Suspendido');
INSERT INTO EstadoTicket(IdEstado, NombreEstado) VALUES(3, 'Terminado');
INSERT INTO EstadoTicket(IdEstado, NombreEstado) VALUES(4, 'Vencido');

GO

CREATE TABLE TareaAsignada(
	IdTarea INT PRIMARY KEY IDENTITY(1,1),
	IdUsuario INT,
	IdTicket INT,
	Fecha DATETIME,
	IdEstado INT
	
	CONSTRAINT FK_Usuario_Asignada FOREIGN KEY(IdUsuario) REFERENCES Usuario(IdUsuario)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_Ticket_Asignada FOREIGN KEY(IdTicket) REFERENCES Ticket(IdTicket)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_Usuario_Estado FOREIGN KEY(IdEstado) REFERENCES EstadoTicket(IdEstado)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
);

