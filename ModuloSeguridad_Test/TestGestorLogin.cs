using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloSeguridad;
using ModuloSeguridad.__obj;

namespace ModuloSeguridad_Test
{
    [TestClass]
    public class TestGestorLogin
    {
        [TestMethod]
        public void Login_UsuarioYContraseñaCorrectos_DebeRetornarUsuarioAutenticado()
        {
            // Arrange
            GestorLogin gestorLogin = new GestorLogin();
            string usuario = "admin";
            string contraseña = "admin";

            // Act
            Usuario usuarioAutenticado = gestorLogin.Login(usuario, contraseña);

            // Assert
            Assert.IsNotNull(usuarioAutenticado);
            Assert.AreEqual("1", usuarioAutenticado.id);
            Assert.AreEqual("Admin", usuarioAutenticado.rol);
        }

        [TestMethod]
        public void Login_UsuarioIncorrecto_DebeRetornarNull()
        {
            // Arrange
            GestorLogin gestorLogin = new GestorLogin();
            string usuario = "usuario_inexistente";
            string contraseña = "contraseña1";

            // Act
            Usuario usuarioAutenticado = gestorLogin.Login(usuario, contraseña);

            // Assert
            Assert.IsNull(usuarioAutenticado);
        }

        [TestMethod]
        public void Login_ContraseñaIncorrecta_DebeRetornarNull()
        {
            // Arrange
            GestorLogin gestorLogin = new GestorLogin();
            string usuario = "usuario1";
            string contraseñaIncorrecta = "contraseña_incorrecta";

            // Act
            Usuario usuarioAutenticado = gestorLogin.Login(usuario, contraseñaIncorrecta);

            // Assert
            Assert.IsNull(usuarioAutenticado);
        }
    }
}
