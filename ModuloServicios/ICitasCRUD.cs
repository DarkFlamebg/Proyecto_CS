using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloServicios
{
    public interface ICitasCRUD
    {
        void AgregarCita(int idUsuario, DateTime fecha, string estadoPago);
        bool ActualizarCita(int citaID, int idUsuario, DateTime fecha, string estadoPago);
        void EliminarCita(int citaID);
        DataTable ObtenerTodasLasCitas(int idUsuario);
    }
}
