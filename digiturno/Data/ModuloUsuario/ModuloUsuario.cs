using digiturno.Data.ModulosData;
using digiturno.Data.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.ModuloUsuario
{
    public class ModuloUsuario
    {
        public int Id { get; set; }

        public string Idusuario { get; set; }

        public int? Idmodulo { get; set; }

        public bool Esactivo { get; set; }

        public Usuarios.Usuarios usuario
        {
            get {
                return UsuariosData.GetUsuarioPorId(Idusuario);
            }
        }

        public Modulos modulo
        {
            get {
                return ModulosData.ModulosData.ObtenerPorId(Idmodulo??0);
            }
        }
        public ModuloUsuario() { }

        public ModuloUsuario(int p_id, string p_idusuario, int? p_idmodulo,bool p_esactivo) {
            Id = p_id;
            Idusuario= p_idusuario;
            Idmodulo = p_idmodulo;
            Esactivo= p_esactivo;
        }
    }
}