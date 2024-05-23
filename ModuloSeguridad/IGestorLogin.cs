using ModuloSeguridad.__obj;

namespace ModuloSeguridad
{
    public interface IGestorLogin
    {
        Usuario Login(string usuario, string contraseña);
    }
}
