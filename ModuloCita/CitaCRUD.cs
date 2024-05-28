using DataBase_Manage;
using System.Data.SqlClient;
using System.Data;

namespace ModuloCita
{
    public class CitaCRUD : ICitaCRUD
    {
        private static CD_Connection conn = new CD_Connection();

        public DataTable ObtenerDetallesCitasPorUsuario(string IdUsuario)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Asignar la conexión
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ObtenerDetallesCitasPorUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", IdUsuario);

                    // Crear un SqlDataAdapter para obtener los resultados del procedimiento almacenado
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        // Llenar un DataTable con los resultados
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw ex;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }
}
