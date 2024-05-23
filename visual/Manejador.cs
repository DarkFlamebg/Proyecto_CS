using ModuloSeguridad;
using ModuloSeguridad.__obj;

namespace Proyecto_CS
{
    public class Manejador
    {
        private readonly IGestorLogin login;

        public Manejador(IGestorLogin login)
        {
            this.login = login;
        }

        public Usuario Login(string usuario, string contraseña)
        {
            return login.Login(usuario, contraseña);
        }
    }
}
