using ModuloSeguridad.__obj;
using System.Collections.Generic;

namespace ModuloRegistro
{
    public interface IOperacionesCRUD
    {
        void AgregarUsuario(Usuario nuevoUsuario);
        void ActualizarUsuario(string id_usuario, string nombre, string apellido, string rol, string direccion, char estado, string telefono);
        void EliminarUsuario(string id_usuario);
        List<Usuario> SelectUsuarios();
        bool ValidarCedula(string cedula);
    }
}
