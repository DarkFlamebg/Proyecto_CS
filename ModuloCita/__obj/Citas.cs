using System;

namespace ModuloServicios.__obj
{
    public class Cita
    {
        public int CitaID { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoPago { get; set; }

        public Cita() { }

        public Cita(string idUsuario, int citaID, DateTime fecha, string estadoPago)
        {
            this.IdUsuario = idUsuario;
            this.CitaID = citaID;
            this.Fecha = fecha;
            this.EstadoPago = estadoPago;
        }
    }
}
