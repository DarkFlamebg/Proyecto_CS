using System.Data.SqlClient;
using System.Data;
using DataBase_Manage;
using ModuloServicios.__obj;

namespace ModuloServicios
{
    public class CitasCRUD : ICitasCRUD
    {
        private readonly CD_Connection conn = new CD_Connection();

        public void AgregarCita(string Idusuario, int citaID)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    //Asignar la conexion
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_AgregarCitaNueva";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Parametros del procedimiento almacenado
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", Idusuario);
                    sqlCommand.Parameters.AddWithValue("@citaID", citaID);

                    //Ejecutar el procedimiento almacenado
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Cita agregada correctamente");
                }
            }
            catch (Exception ex)
            {
                //manejo de errores
                throw ex;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public bool ActualizarCita(int citaID, string IdUsuario, DateTime FechaEmision, string EstadoPago)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    //Asignar la conexion
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ActualizarCita";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Parametros del procedimiento almacenado
                    sqlCommand.Parameters.AddWithValue("@citaID", citaID);
                    sqlCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    sqlCommand.Parameters.AddWithValue("@Fecha", FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@EstadoPago", EstadoPago);

                    //Ejecutar el procedimiento almacenado
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

        public void EliminarCita(string IdUsuario, int citaID)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    //Asignar la conexion
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_EliminarCitaDeUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    sqlCommand.Parameters.AddWithValue("@citaID", citaID);

                    //Ejecutar el stored procedure
                    sqlCommand.ExecuteNonQuery();
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

        public DataTable ObtenerTodasLasCitas(string IdUsuario, int citaID)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_ObtenerTodasCitas";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Parametros del procedimiento almacenado
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    sqlCommand.Parameters.AddWithValue("@citaID", citaID);

                    //Crear un sqlDataAdapter para obtener los resultados del procedimiento almacenado
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        //Lenar el datatable con los resultados
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable; 
                    }
                }
            }
            catch (Exception ex)
            {
                //Manejo de errores
                throw ex;
            }
            finally 
            {
                conn.CloseConnection( );
            }
        }
        public void InsertarCita(int IdDetalleCita, DateTime FechaEmision, string EstadoPago)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    //Asignar la conexion
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "sp_InsertarCita";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Parametros del procedimientos almacenado
                    sqlCommand.Parameters.AddWithValue("@Id_DetalleCita", IdDetalleCita);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@EstadoPago", EstadoPago);

                    //Ejecutar el procedimiento almacenado
                    sqlCommand.ExecuteNonQuery();

                    Console.WriteLine("Cita Insertada correctamente");
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
