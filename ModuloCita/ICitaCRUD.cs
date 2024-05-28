using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCita
{
    public interface ICitaCRUD
    {
        DataTable ObtenerDetallesCitasPorUsuario(string IdUsuario);
    }
}
