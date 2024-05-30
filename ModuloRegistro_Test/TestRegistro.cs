using ModuloRegistro;
using ModuloSeguridad.__obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloRegistro_Test
{
    [TestClass]
    public class TestRegistro
    {
        [TestMethod]
        public void AgregarUsuario_DeberiaAgregarseCorrectamente()
        {
            // Arrange
            Usuario nuevoUsuario = new Usuario
            {
                // Define los valores del nuevo usuario aqu�
                id = "2",
                nombre = "Nombre",
                apellido = "Apellido",
                usuario = "Usuario",
                contraseña = "Contraseña",
                rol = "Rol",
                direccion = "Direccion",
                telefono = "Telefono"
            };

            // Act
            OperacionesCRUD instancia = new OperacionesCRUD(); // Reemplaza con el nombre de tu clase
            instancia.AgregarUsuario(nuevoUsuario);

            // Assert

        }
    }
}
