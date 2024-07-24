using System;
using System.Data;
using System.Data.SqlClient;
using DataBase_Manage;
using ModuloServicios.__obj;

namespace ModuloServicios
{
    public class CitasCRUD : ICitasCRUD
    {
        private readonly CD_Connection conn = new CD_Connection();

        public void AgregarCita(int idUsuario, DateTime fecha, string estadoPago)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_AgregarCita";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    sqlCommand.Parameters.AddWithValue("@Fecha", fecha);
                    sqlCommand.Parameters.AddWithValue("@EstadoPago", estadoPago);

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Cita agregada correctamente");
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

        public bool ActualizarCita(int citaID, int idUsuario, DateTime fecha, string estadoPago)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ActualizarCita";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@CitaID", citaID);
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    sqlCommand.Parameters.AddWithValue("@Fecha", fecha);
                    sqlCommand.Parameters.AddWithValue("@EstadoPago", estadoPago);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
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


        public void EliminarCita(int citaID)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_EliminarCita";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CitaID", citaID);

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Cita eliminada correctamente");
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
