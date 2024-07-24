CREATE TABLE Usuarios (
    Id_Usuario INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Usuario NVARCHAR(50),
    Contraseña NVARCHAR(256),
    Rol NVARCHAR(50),
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(20),
    Estado CHAR DEFAULT 'A',
);



CREATE TABLE Citas (
    CitaID INT PRIMARY KEY IDENTITY(1,1),
    Id_Usuario INT,
    Fecha DATETIME,
    EstadoPago NVARCHAR(50),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);





---------StoreProcedures------------
-- Procedimiento para agregar una cita
CREATE PROCEDURE sp_AgregarCita
    @Id_Usuario INT,
    @Fecha DATETIME,
    @EstadoPago NVARCHAR(50)
AS
BEGIN
    INSERT INTO Citas (Id_Usuario, Fecha, EstadoPago)
    VALUES (@Id_Usuario, @Fecha, @EstadoPago);
END

-- Procedimiento para actualizar una cita
CREATE PROCEDURE sp_ActualizarCita
    @CitaID INT,
    @Fecha DATETIME,
    @EstadoPago NVARCHAR(50)
AS
BEGIN
    UPDATE Citas
    SET Fecha = @Fecha, EstadoPago = @EstadoPago
    WHERE CitaID = @CitaID;
END

-- Procedimiento para eliminar una cita
CREATE PROCEDURE sp_EliminarCita
    @CitaID INT
AS
BEGIN
    DELETE FROM Citas
    WHERE CitaID = @CitaID;
END

-- sp_ObtenerTodasLasCitas
CREATE PROCEDURE sp_ObtenerTodasLasCitas
    @Id_Usuario INT
AS
BEGIN
    SELECT CitaID, Fecha, EstadoPago
    FROM Citas
    WHERE Id_Usuario = @Id_Usuario;
END

-- sp_ObtenerDetallesCitasPorUsuario
CREATE PROCEDURE sp_ObtenerDetallesCitasPorUsuario
    @Id_Usuario INT
AS
BEGIN
    SELECT CitaID, Fecha, EstadoPago
    FROM Citas
    WHERE Id_Usuario = @Id_Usuario;
END


-- sp_InsertarUsuario
CREATE PROCEDURE sp_InsertarUsuario
    @Id_Usuario INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Usuario NVARCHAR(50),
    @Contraseña NVARCHAR(256),
    @Rol NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Estado CHAR(1)
AS
BEGIN
    INSERT INTO Usuarios (Id_Usuario, Nombre, Apellido, Usuario, Contraseña, Rol, Direccion, Telefono, Estado)
    VALUES (@Id_Usuario, @Nombre, @Apellido, @Usuario, @Contraseña, @Rol, @Direccion, @Telefono, @Estado);
END

-- sp_ActualizarUsuario
CREATE PROCEDURE sp_ActualizarUsuario
    @IdUsuario INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Rol NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Estado CHAR(1)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Usuario = @Usuario,
        Rol = @Rol,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Estado = @Estado
    WHERE Id_Usuario = @IdUsuario;
END


-- sp_EliminarUsuario
CREATE PROCEDURE sp_EliminarUsuario
    @IdUsuario INT
AS
BEGIN
    DELETE FROM Usuarios
    WHERE Id_Usuario = @IdUsuario;
END


-- sp_SelectUsuarios
CREATE PROCEDURE sp_SelectUsuarios
AS
BEGIN
    SELECT Id_Usuario, Nombre, Apellido, Usuario, Rol, Direccion, Telefono, Estado
    FROM Usuarios;
END


-- Inserción de usuarios de prueba
INSERT INTO Usuarios (Id_Usuario, Nombre, Apellido, Usuario, Contraseña, Rol, Direccion, Telefono, Estado)
VALUES 
(1, 'Juan', 'Perez', 'jperez', 'password1', 'Cliente', 'Calle 123', '1234567890', 'A'),
(2, 'Maria', 'Gomez', 'mgomez', 'password2', 'Cliente', 'Avenida 456', '0987654321', 'A');

-- Inserción de citas de prueba
INSERT INTO Citas (Id_Usuario, Fecha, EstadoPago)
VALUES 
(1, '2024-07-25', 'Pagado'),
(2, '2024-07-26', 'Pendiente');

-- Ejecutar procedimientos almacenados para agregar citas de prueba
EXEC sp_AgregarCita @Id_Usuario = 1, @Fecha = '2024-08-01 14:00:00', @EstadoPago = 'Pendiente';
EXEC sp_AgregarCita @Id_Usuario = 2, @Fecha = '2024-08-01 16:00:00', @EstadoPago = 'Pagado';

