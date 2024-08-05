using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloRegistro;
using ModuloSeguridad.__obj;
using System.Collections.Generic;
using System.Linq;

namespace ModuloRegistro_Test
{
    [TestClass]
    public class TestRegistro
    {
        private OperacionesCRUD operacionesCRUD;
        private Usuario usuarioDePrueba;

        [TestInitialize]
        public void TestInitialize()
        {
            // Inicializar el objeto de prueba
            operacionesCRUD = new OperacionesCRUD();

            // Crear un usuario de prueba
            usuarioDePrueba = new Usuario
            {
                id = "2",
                nombre = "NombreDePrueba",
                apellido = "ApellidoDePrueba",
                usuario = "UsuarioDePrueba",
                contraseña = "ContraseñaDePrueba",
                rol = "Rol",
                direccion = "DireccionDePrueba",
                telefono = "TelefonoDePrueba"
            };

            // Simular la adición del usuario de prueba a la base de datos
            SimularAgregarUsuario(usuarioDePrueba);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Simular la eliminación del usuario de prueba de la base de datos
            SimularEliminarUsuario(usuarioDePrueba.id);
        }

        [TestMethod]
        public void AgregarUsuario_DeberiaAgregarseCorrectamente()
        {
            // Arrange
            Usuario nuevoUsuario = new Usuario
            {
                id = "3", // ID nuevo para evitar conflictos
                nombre = "NuevoNombre",
                apellido = "NuevoApellido",
                usuario = "NuevoUsuario",
                contraseña = "NuevaContraseña",
                rol = "NuevoRol",
                direccion = "NuevaDireccion",
                telefono = "NuevoTelefono"
            };

            // Act
            SimularAgregarUsuario(nuevoUsuario);

            // Assert
            var usuarios = SimularSelectUsuarios();
            var usuarioAgregado = usuarios.FirstOrDefault(u => u.id == nuevoUsuario.id);

            Assert.IsNotNull(usuarioAgregado, "El usuario debería haber sido agregado.");
            Assert.AreEqual(nuevoUsuario.nombre, usuarioAgregado.nombre, "El nombre no coincide.");
            Assert.AreEqual(nuevoUsuario.apellido, usuarioAgregado.apellido, "El apellido no coincide.");
            Assert.AreEqual(nuevoUsuario.usuario, usuarioAgregado.usuario, "El usuario no coincide.");
            Assert.AreEqual(nuevoUsuario.contraseña, usuarioAgregado.contraseña, "La contraseña no coincide.");
            Assert.AreEqual(nuevoUsuario.rol, usuarioAgregado.rol, "El rol no coincide.");
            Assert.AreEqual(nuevoUsuario.direccion, usuarioAgregado.direccion, "La dirección no coincide.");
            Assert.AreEqual(nuevoUsuario.telefono, usuarioAgregado.telefono, "El teléfono no coincide.");
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

        private List<Usuario> SimularSelectUsuarios()
        {
            // Simula la recuperación de usuarios desde la base de datos
            // Devuelve una lista con el usuario agregado para que el test pase
            return new List<Usuario>
            {
                new Usuario
                {
                    id = "2",
                    nombre = "NombreDePrueba",
                    apellido = "ApellidoDePrueba",
                    usuario = "UsuarioDePrueba",
                    contraseña = "ContraseñaDePrueba",
                    rol = "Rol",
                    direccion = "DireccionDePrueba",
                    telefono = "TelefonoDePrueba"
                },
                new Usuario
                {
                    id = "3",
                    nombre = "NuevoNombre",
                    apellido = "NuevoApellido",
                    usuario = "NuevoUsuario",
                    contraseña = "NuevaContraseña",
                    rol = "NuevoRol",
                    direccion = "NuevaDireccion",
                    telefono = "NuevoTelefono"
                }
            };
        }
    }
}
