using System.Data;
using System.Data.SqlClient;
using DataBase_Manage;
using ModuloSeguridad;
using ModuloSeguridad.__obj;

namespace ModuloRegistro
{
    public class OperacionesCRUD //: IOperacionesCRUD
    {
        private readonly CD_Connection conn = new CD_Connection();
        private Encriptador encriptar = new Encriptador();

        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Asignar la conexión
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "InsertarUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", nuevoUsuario.id);
                    sqlCommand.Parameters.AddWithValue("@Nombre", nuevoUsuario.nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", nuevoUsuario.apellido);
                    sqlCommand.Parameters.AddWithValue("@User", nuevoUsuario.usuario);
                    sqlCommand.Parameters.AddWithValue("@Contraseña", encriptar.Encriptar(nuevoUsuario.contraseña));
                    sqlCommand.Parameters.AddWithValue("@Rol", nuevoUsuario.rol);
                    sqlCommand.Parameters.AddWithValue("@Direccion", nuevoUsuario.direccion);
                    sqlCommand.Parameters.AddWithValue("@Telefono", nuevoUsuario.telefono);

                    // Ejecutar el procedimiento almacenado
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Usuario agregado correctamente.");
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

        public void ActualizarUsuario(string id_usuario, string nombre, string apellido, string rol, string direccion, char estado, string telefono)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Asignar la conexión
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "ActualizarUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdUsuario", id_usuario);
                    sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", apellido);
                    sqlCommand.Parameters.AddWithValue("@Rol", rol);
                    sqlCommand.Parameters.AddWithValue("@Direccion", direccion);
                    sqlCommand.Parameters.AddWithValue("@Telefono", telefono);
                    sqlCommand.Parameters.AddWithValue("@Estado", estado);

                    // Ejecutar el Stored Procedure
                    sqlCommand.ExecuteNonQuery();
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

        public void EliminarUsuario(string idUsuario)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Asignar la conexión
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "EliminarUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    // Ejecutar el Stored Procedure
                    sqlCommand.ExecuteNonQuery();
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

        public List<Usuario> SelectUsuarios()
        {
            DataTable dataTable = new DataTable();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Asignar la conexión
                    sqlCommand.Connection = conn.OpenConnection();
                    sqlCommand.CommandText = "SelectUsuarios";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        // Llenar el DataTable con los resultados del Stored Procedure
                        dataAdapter.Fill(dataTable);
                    }
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    Usuario us = new Usuario()
                    {
                        id = row["Id_Usuario"].ToString(),
                        usuario = row["User"].ToString(),
                        nombre = row["Nombre"].ToString(),
                        apellido = row["Apellido"].ToString(),
                        rol = row["Rol"].ToString(),
                        direccion = row["Direccion"].ToString(),
                        telefono = row["Telefono"].ToString(),
                        estado = Convert.ToChar(row["Estado"])
                    };
                    usuarios.Add(us);
                }

                return usuarios;
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

        public bool ValidarCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula) || cedula.Length != 10)
            {
                return false;
            }

            // Verificar que los primeros 9 caracteres sean dígitos numéricos
            if (!cedula.Substring(0, 9).All(char.IsDigit))
            {
                return false;
            }

            // Obtener el último dígito (dígito verificador)
            int verificador = int.Parse(cedula[9].ToString());

            // Calcular el dígito verificador válido
            int suma = 0;
            for (int i = 0; i < 9; i++)
            {
                int digito = int.Parse(cedula[i].ToString());
                if (i % 2 == 0)
                {
                    digito *= 2;
                    if (digito > 9)
                    {
                        digito -= 9;
                    }
                }
                suma += digito;
            }

            int digitoVerificadorValido = 0;
            if (suma % 10 != 0)
            {
                digitoVerificadorValido = 10 - (suma % 10);
            }

            // Comparar el dígito verificador con el calculado
            return verificador == digitoVerificadorValido;
        }
    }
}
