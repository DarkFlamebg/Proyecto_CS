using ModuloRegistro;
using ModuloSeguridad.__obj;

namespace ModuloRegistro_Test
{
    [TestClass]
    public class TestActualizar
    {
        private OperacionesCRUD operacionesCRUD;
        private Usuario testUsuario;

        [TestInitialize]
        public void TestInitialize()
        {
            // Inicializar el objeto de prueba
            operacionesCRUD = new OperacionesCRUD();

            // Crear un usuario de prueba
            testUsuario = new Usuario
            {
                id = "testId",
                nombre = "TestNombre",
                apellido = "TestApellido",
                usuario = "TestUsuario",
                contraseña = "TestContraseña",
                rol = "Usuario",
                direccion = "TestDireccion",
                telefono = "1234567890",
                estado = 'A'
            };

            // Agregar el usuario de prueba a la base de datos
            operacionesCRUD.AgregarUsuario(testUsuario);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Eliminar el usuario de prueba de la base de datos
            operacionesCRUD.EliminarUsuario(testUsuario.id);
        }

        [TestMethod]
        public void ActualizarUsuario_DeberiaActualizarUsuarioCorrectamente()
        {
            // Arrange
            string nuevoNombre = "NuevoNombre";
            string nuevoApellido = "NuevoApellido";
            string nuevoRol = "Admin";
            string nuevaDireccion = "NuevaDireccion";
            char nuevoEstado = 'I';
            string nuevoTelefono = "0987654321";

            // Act
            operacionesCRUD.ActualizarUsuario(testUsuario.id, nuevoNombre, nuevoApellido, nuevoRol, nuevaDireccion, nuevoEstado, nuevoTelefono);

            // Assert
            var usuarios = operacionesCRUD.SelectUsuarios();
            var usuarioActualizado = usuarios.FirstOrDefault(u => u.id == testUsuario.id);

            Assert.IsNotNull(usuarioActualizado, "El usuario actualizado no debería ser nulo.");
            Assert.AreEqual(nuevoNombre, usuarioActualizado.nombre, "El nombre no coincide.");
            Assert.AreEqual(nuevoApellido, usuarioActualizado.apellido, "El apellido no coincide.");
            Assert.AreEqual(nuevoRol, usuarioActualizado.rol, "El rol no coincide.");
            Assert.AreEqual(nuevaDireccion, usuarioActualizado.direccion, "La dirección no coincide.");
            Assert.AreEqual(nuevoEstado, usuarioActualizado.estado, "El estado no coincide.");
            Assert.AreEqual(nuevoTelefono, usuarioActualizado.telefono, "El teléfono no coincide.");
        }
    }
}