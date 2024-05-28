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
        void AgregarCita(string Idusuario, int citaID);
        bool ActualizarCita(int citaID, string IdUsuario, DateTime FechaEmision, string EstadoPago);
        void EliminarCita(string IdUsuario, int citaID);
        DataTable ObtenerTodasLasCitas(string IdUsuario, int citaID);
        void InsertarCita(int IdDetalleCita, DateTime FechaEmision, string EstadoPago);
    }
}
