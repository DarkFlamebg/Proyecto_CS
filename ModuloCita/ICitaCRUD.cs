using System.Data;

namespace ModuloCita
{
    public interface ICitaCRUD
    {
        DataTable ObtenerTodasLasCitas(int idUsuario);
        DataTable ObtenerDetallesCitasPorUsuario(string IdUsuario);
    }
}
