-- Create DataBase LegalPro

Use LegalPro

CREATE TABLE Usuarios (
    idUsuario int PRIMARY KEY IDENTITY(1,1),
    Nombre Varchar(100),
    CorreoElectronico Varchar(100),
    Rol Varchar(50),
    Contraseña Varchar(255) NOT NULL
);

CREATE TABLE Cliente (
    idCliente int PRIMARY KEY IDENTITY(1,1),
	Identificación Varchar(13) NOT NULL,
    Nombres Varchar(100) NOT NULL,
	Apellidos Varchar(100) NOT NULL,
    CorreoElectronico Varchar(100),
	Direccion Varchar(500),
    Telefono Varchar(20),
	FechaNacimiento Date
);

CREATE TABLE IngresoClientes (
    idIngresoClientes int PRIMARY KEY IDENTITY(1,1),
    NombresUsuario Varchar(50) NOT NULL,
    Contraseña Varchar(255) NOT NULL,
	idCliente int FOREIGN KEY REFERENCES Cliente(idCliente)
);

CREATE TABLE Caso (
    idCaso int PRIMARY KEY IDENTITY(1,1),
    NumeroCaso Varchar(20) NOT NULL,
    NombreCaso Varchar(50),
    FechaInicio Date,
    Nota Varchar(500),
	idCliente int FOREIGN KEY REFERENCES Cliente(idCliente)
);

CREATE TABLE Plazo (
    idPlazo int PRIMARY KEY IDENTITY(1,1),
	NombrePlazo Varchar(200),
	Descripcion Varchar(255),
    FechaPlazo Date NOT NULL,
    Notificado bit DEFAULT 0,
	idCaso int FOREIGN KEY REFERENCES Caso(idCaso)
);

CREATE TABLE AsignacionTarea (
    idAsignacionTarea int PRIMARY KEY IDENTITY(1,1),
	NombreTarea Varchar(100),
	Estado Varchar(50),
    Descripcion Varchar(500),
    FechaLimite Date,
    ArchivoRutaEvidencia Varchar(255),
	idCaso int FOREIGN KEY REFERENCES Caso(idCaso),
	AsignacionUsuario int FOREIGN KEY REFERENCES Usuarios(idUsuario)
);

CREATE TABLE AuditoriaUsuarios (
    idHistorial int PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME DEFAULT GETDATE(),
    Descripcion Varchar(500),
	idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario)
);

CREATE TABLE EventoCalendario (
    idEvento int PRIMARY KEY IDENTITY(1,1),
    Titulo Varchar(100) NOT NULL,
    Descripcion Varchar(500),
    FechaInicio Datetime NOT NULL,
    FechaFin Datetime,
    TipoEvento Varchar(50),
    Notificar Bit Default 1,
	idCaso int FOREIGN KEY REFERENCES Caso(idCaso),
);
