using digiturno.Data.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.UsuarioRol
{
    public class UsuarioRol
    {

        public string Idusuario { get; set; }

        public int Idrol{ get; set; }

        public Usuarios.Usuarios usuario {
            get {
                return UsuariosData.GetUsuarioPorId(Idusuario);
            }
        }

        public Roles.Roles rol
        {
            get {
                return Roles.RolesData.ObtenerPorId(Idrol);
            }
        }
        public UsuarioRol() { }

        public UsuarioRol(string p_idusuario,int p_idrol) {
            Idusuario= p_idusuario;
            Idrol= p_idrol;
        }
    }
}