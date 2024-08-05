using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloSeguridad;
using ModuloSeguridad.__obj;

namespace ModuloSeguridad_Test
{
    [TestClass]
    public class TestGestorLogin
    {
        private GestorLogin gestorLogin;

        [TestInitialize]
        public void TestInitialize()
        {
            // Inicializar el objeto de prueba
            gestorLogin = new GestorLogin();

            // Simular el registro de un usuario válido en el sistema
            SimularAgregarUsuario("admin", "admin", "1", "Admin");
            SimularAgregarUsuario("usuario1", "contraseña1", "2", "Usuario");
        }

        

        [TestMethod]
        public void Login_UsuarioIncorrecto_DebeRetornarNull()
        {
            // Arrange
            string usuario = "usuario_inexistente";
            string contraseña = "contraseña1";

            // Act
            Usuario usuarioAutenticado = gestorLogin.Login(usuario, contraseña);

            // Assert
            Assert.IsNull(usuarioAutenticado, "El usuario autenticado debería ser nulo.");
        }

        [TestMethod]
        public void Login_ContraseñaIncorrecta_DebeRetornarNull()
        {
            // Arrange
            string usuario = "usuario1";
            string contraseñaIncorrecta = "contraseña_incorrecta";

            // Act
            Usuario usuarioAutenticado = gestorLogin.Login(usuario, contraseñaIncorrecta);

            // Assert
            Assert.IsNull(usuarioAutenticado, "El usuario autenticado debería ser nulo.");
        }

        // Métodos simulados
        private void SimularAgregarUsuario(string usuario, string contraseña, string id, string rol)
        {
            // Simula la adición del usuario en el sistema
            // Aquí deberías configurar tu gestor de login para que retorne este usuario para el login si los datos son correctos
        }
    }
}
