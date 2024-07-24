using DataBase_Manage;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ModuloCita
{
    public class CitaCRUD : ICitaCRUD
    {
        private readonly CD_Connection conn = new CD_Connection();

        public DataTable ObtenerDetallesCitasPorUsuario(string IdUsuario)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ObtenerDetallesCitasPorUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", IdUsuario);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public DataTable ObtenerTodasLasCitas(int idUsuario)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ObtenerTodasLasCitas";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", idUsuario);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }
}
