using ModuloCita;

namespace ModuloCita_Test
{
    [TestClass]
    public class TestCita
    {
        [TestMethod]
        public void ObtenerDetallesCitasPorUsuario_DeberiaObtenerDatos()
        {
            // Arrange
            string idUsuario = "1";
            CitaCRUD citaCRUD = new CitaCRUD();

            // Act
            var detallesCitas = citaCRUD.ObtenerDetallesCitasPorUsuario(idUsuario);

            // Assert
            Assert.IsNotNull(detallesCitas, "El resultado de las citas no debería ser nulo");
            Assert.IsTrue(detallesCitas.Rows.Count > 0, "Se esperaba al menos una fila en el resultado");
            // Puedes agregar más aserciones según la estructura de tu resultado esperado.
        }
    }
}