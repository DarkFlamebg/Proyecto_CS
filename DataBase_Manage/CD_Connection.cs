using System.Data;
using System.Data.SqlClient;

namespace DataBase_Manage
{
    public class CD_Connection
    {
        private SqlConnection DB_Connection = new SqlConnection("Server=DESKTOP-AOFHQJ5\\SQLEXPRESS;Database=ProyectoCS; Integrated Security=true");

        public SqlConnection OpenConnection()
        {
            try
            {
                if (DB_Connection.State == ConnectionState.Closed)
                    DB_Connection.Open();

                return DB_Connection;
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, log, mostrar mensaje, etc.)
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return null;
            }
        }

        public SqlConnection CloseConnection()
        {
            try
            {
                if (DB_Connection.State == ConnectionState.Open)
                    DB_Connection.Close();

                return DB_Connection;
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, log, mostrar mensaje, etc.)

                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
                return null;
            }
        }
    }
}
