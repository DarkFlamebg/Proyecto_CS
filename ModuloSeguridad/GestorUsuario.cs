using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloSeguridad.__obj;

namespace ModuloSeguridad
{
    public class GestorUsuario
    {
        public GestorLogs log = new GestorLogs();

        // Lista para almacenar usuarios
        private static GestorUsuario instancia;
        public List<Usuario> users = new List<Usuario>();
        

        private GestorUsuario() { }

        public static GestorUsuario Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorUsuario();
                }
                return instancia;
            }
        }

        //Asigna un Rol y se guarda un log de quien asigno el rol o lo modifico
        public void AsignarRol(Usuario usuario, string nombreRol, string mod)
        {
            if (nombreRol == "Admin")
            {
                usuario.rol = "Admin";
            }
            else if (nombreRol == "Supervisor")
            {
                usuario.rol = "Supervisor";
            }
            else if (nombreRol == "Trabajador")
            {
                usuario.rol = "Trabajador";
            }
            else if (nombreRol == "Cliente")
            {
                usuario.rol = "Cliente";
            }

            log.RegistrarLog(mod, $"Cambio de rol al usuario:{usuario.nombre} a rol: {nombreRol}");
        }

        

    }
}
