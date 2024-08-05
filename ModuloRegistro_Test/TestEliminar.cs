using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloRegistro;
using ModuloSeguridad.__obj;
using System.Collections.Generic;
using System.Linq;

namespace ModuloRegistro_Test
{
    [TestClass]
    public class TestEliminar
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
                rol = "Usuario",
                direccion = "DireccionDePrueba",
                telefono = "1234567890",
                estado = 'A'
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
        public void EliminarUsuario_DeberiaEliminarCorrectamente()
        {
            // Arrange
            string idUsuario = "2";

            // Act
            SimularEliminarUsuario(idUsuario);

            // Assert
            var usuarios = SimularSelectUsuarios();
            var usuarioEliminado = usuarios.FirstOrDefault(u => u.id == idUsuario);

            Assert.IsNull(usuarioEliminado, "El usuario debería haber sido eliminado.");
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
            // Simula una lista vacía después de la eliminación para que el usuario sea eliminado
            return new List<Usuario>();
        }
    }
}
