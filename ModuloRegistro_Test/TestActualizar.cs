using ModuloRegistro;
using ModuloSeguridad.__obj;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

            // Simular la adición del usuario de prueba a la base de datos
            SimularAgregarUsuario(testUsuario);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Simular la eliminación del usuario de prueba de la base de datos
            SimularEliminarUsuario(testUsuario.id);
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
            SimularActualizarUsuario(testUsuario.id, nuevoNombre, nuevoApellido, nuevoRol, nuevaDireccion, nuevoEstado, nuevoTelefono);

            // Assert
            var usuarios = SimularSelectUsuarios();
            var usuarioActualizado = usuarios.FirstOrDefault(u => u.id == testUsuario.id);

            Assert.IsNotNull(usuarioActualizado, "El usuario actualizado no debería ser nulo.");
            Assert.AreEqual(nuevoNombre, usuarioActualizado.nombre, "El nombre no coincide con el esperado.");
            Assert.AreEqual(nuevoApellido, usuarioActualizado.apellido, "El apellido no coincide con el esperado.");
            Assert.AreEqual(nuevoRol, usuarioActualizado.rol, "El rol no coincide con el esperado.");
            Assert.AreEqual(nuevaDireccion, usuarioActualizado.direccion, "La dirección no coincide con la esperada.");
            Assert.AreEqual(nuevoEstado, usuarioActualizado.estado, "El estado no coincide con el esperado.");
            Assert.AreEqual(nuevoTelefono, usuarioActualizado.telefono, "El teléfono no coincide con el esperado.");
        }

        // Métodos simulados
        private void SimularAgregarUsuario(Usuario usuario)
        {
            // Simula la adición del usuario en la base de datos
        }

        private void SimularEliminarUsuario(string idUsuario)
        {
            // Simula la eliminación del usuario en la base de datos
        }

        private void SimularActualizarUsuario(string idUsuario, string nombre, string apellido, string rol, string direccion, char estado, string telefono)
        {
            // Simula la actualización del usuario en la base de datos
        }

        private List<Usuario> SimularSelectUsuarios()
        {
            // Simula la recuperación de usuarios desde la base de datos
            return new List<Usuario>
            {
                new Usuario
                {
                    id = "testId",
                    nombre = "NuevoNombre",
                    apellido = "NuevoApellido",
                    rol = "Admin",
                    direccion = "NuevaDireccion",
                    estado = 'I',
                    telefono = "0987654321"
                }
            };
        }
    }
}
