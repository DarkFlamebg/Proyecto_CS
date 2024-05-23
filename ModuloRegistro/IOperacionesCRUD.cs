﻿using ModuloSeguridad.__obj;

namespace ModuloRegistro
{
    public interface IOperacionesCRUD
    {
        void AgregarUsuario(Usuario nuevoUsuario);
        void ActualizarUsuario(string id_usuario, string nombre, string apellido,
            string rol, string direccion, string estado, string telefono);
        void EliminarUsuario(string id_usuario);
        List<Usuario> SelectUsuarios();
        public bool ValidarCedula(string cedula);
    }
}
