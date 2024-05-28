using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloServicios.__obj
{
    public class Cita
    {
        public int CitaID { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoPago { get; set; }

        public Cita() { }

        public Cita(string idUsuario, int CitaID, DateTime Fecha, string EstadoPago)
        {
            this.IdUsuario = idUsuario;
            this.CitaID = CitaID;
            this.Fecha = Fecha;
            this.EstadoPago = EstadoPago;
        }
    }

}
