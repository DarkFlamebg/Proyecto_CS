using ModuloRegistro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloRegistro_Test
{
    [TestClass]
    public class TestEliminar
    {
        [TestMethod]
        public void EliminarUsuario_DeberiaEliminarCorrectamente()
        {
            // Arrange
            string idUsuario = "2";

            // Puedes utilizar un objeto mock para simular la conexión y el comando SQL
            // También podrías utilizar una base de datos de prueba real, asegurándote de que no afecte a datos importantes.

            // Act
            OperacionesCRUD instancia = new OperacionesCRUD(); // Reemplaza con el nombre de tu clase
            instancia.EliminarUsuario(idUsuario);


        }
    }
}
