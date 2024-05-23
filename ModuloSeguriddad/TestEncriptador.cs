
using ModuloSeguridad;

namespace ModuloSeguridadTest
{
    [TestClass]
    public class EncriptadorTests
    {
        [TestMethod]
        public void EncriptarYDesencriptar_TextoPlano_RetornaTextoOriginal()
        {
            // Arrange
            Encriptador encriptador = new Encriptador();
            string textoOriginal = "Hola, mundo!";

            // Act
            string textoCifrado = encriptador.Encriptar(textoOriginal);
            string textoDesencriptado = encriptador.Desencriptar(textoCifrado);

            // Assert
            Assert.AreEqual(textoOriginal, textoDesencriptado);
        }

        [TestMethod]
        public void EncriptarYDesencriptar_TextoVacio_RetornaTextoVacio()
        {
            // Arrange
            Encriptador encriptador = new Encriptador();
            string textoOriginal = "";

            // Act
            string textoCifrado = encriptador.Encriptar(textoOriginal);
            string textoDesencriptado = encriptador.Desencriptar(textoCifrado);

            // Assert
            Assert.AreEqual(textoOriginal, textoDesencriptado);
        }

        [TestMethod]
        public void EncriptarYDesencriptar_TextoNulo_RetornaNulo()
        {
            // Arrange
            Encriptador encriptador = new Encriptador();
            string textoOriginal = null;

            // Act
            string textoCifrado = encriptador.Encriptar(textoOriginal);
            string textoDesencriptado = encriptador.Desencriptar(textoCifrado);

            // Assert
            Assert.IsNull(textoOriginal);
            Assert.IsNull(textoCifrado);
            Assert.IsNull(textoDesencriptado);
        }

        [TestMethod]
        public void EncriptarYDesencriptar_CaracteresEspeciales_RetornaTextoOriginal()
        {
            // Arrange
            Encriptador encriptador = new Encriptador();
            string textoOriginal = "!@#$%^&*()_+";

            // Act
            string textoCifrado = encriptador.Encriptar(textoOriginal);
            string textoDesencriptado = encriptador.Desencriptar(textoCifrado);

            // Assert
            Assert.AreEqual(textoOriginal, textoDesencriptado);
        }

        // Puedes agregar más pruebas para casos especiales, como texto nulo, caracteres especiales, etc.
    }
}