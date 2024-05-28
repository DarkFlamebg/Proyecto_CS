using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloServicios;
using System;
using System.Data;
namespace ModuloServicio_Test
{
    [TestClass]
    public class CitasCRUDTest
    {
        private class CitasCRUDTests
        {
            private CitasCRUD citasCRUD;
            [TestInitialize]
            public void Setup()
            {
                citasCRUD = new CitasCRUD();
            }

            [TestMethod]
            public void ObtenerTodasLasCitas_DeberiaRetornarCitasCorrectamente()
            {
                // Arrange
                string idUsuario = "3";
                citasCRUD.AgregarCita(idUsuario, 101);
                citasCRUD.AgregarCita(idUsuario, 102);

                // Act
                var citas = citasCRUD.ObtenerTodasLasCitas(idUsuario, 0);

                // Assert
                Assert.IsNotNull(citas, "La lista de citas no debería ser nula.");
                Assert.IsTrue(citas.Rows.Count >= 2, "Se esperaban al menos dos citas.");
            }

            [TestMethod]
            public void AgregarCita_DeberiaAgregarCitaCorrectamente()
            {
                // Arrange
                string idUsuario = "3";
                int citaID = 123;

                // Act
                citasCRUD.AgregarCita(idUsuario, citaID);

                // Assert
                var citas = citasCRUD.ObtenerTodasLasCitas(idUsuario, citaID);
                Assert.IsNotNull(citas, "La lista de citas no debería ser nula.");
                Assert.IsTrue(citas.Rows.Count > 0, "Se esperaba al menos una cita.");
                DataRow cita = citas.Rows[0];
                Assert.AreEqual(idUsuario, cita["IdUsuario"].ToString(), "El IdUsuario de la cita no coincide.");
                Assert.AreEqual(citaID, int.Parse(cita["CitaID"].ToString()), "El ID de la cita no coincide.");
            }

            [TestMethod]
            public void InsertarCita_DeberiaInsertarCitaCorrectamente()
            {
                // Arrange
                int idDetalleCita = 1;
                DateTime fechaEmision = DateTime.Now;
                string estadoPago = "Pagado";
                citasCRUD.InsertarCita(idDetalleCita, fechaEmision, estadoPago);

                // Act
                var citas = citasCRUD.ObtenerTodasLasCitas("", idDetalleCita); // "" puede representar cualquier usuario si no se usa

                // Assert
                Assert.IsNotNull(citas, "La lista de citas no debería ser nula.");
                Assert.IsTrue(citas.Rows.Count > 0, "Se esperaba al menos una cita.");
                DataRow cita = citas.Rows[0];
                Assert.AreEqual(fechaEmision, DateTime.Parse(cita["Fecha"].ToString()), "La fecha de emisión de la cita no coincide.");
                Assert.AreEqual(estadoPago, cita["EstadoPago"].ToString(), "El estado de pago de la cita no coincide.");
            }


            [TestMethod]
            public void EliminarCita_DeberiaEliminarCitaCorrectamente()
            {
                // Arrange
                string idUsuario = "3";
                int citaID = 123;
                citasCRUD.AgregarCita(idUsuario, citaID);

                // Act
                citasCRUD.EliminarCita(idUsuario, citaID);

                // Assert
                var citas = citasCRUD.ObtenerTodasLasCitas(idUsuario, citaID);
                Assert.AreEqual(0, citas.Rows.Count, "La lista de citas debería estar vacía después de eliminar la cita.");
            }

        }

    }
}