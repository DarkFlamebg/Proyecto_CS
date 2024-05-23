using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSeguridad.__obj
{
    public class Log
    {
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }

        public Log() { }

        public Log(string usuario, string accion, DateTime fecha)
        {
            Usuario = usuario;
            Accion = accion;
            Fecha = fecha;
        }

        public string toSring()
        {
            return $"{Fecha} {Usuario}: {Accion}";
        }
    }
}
