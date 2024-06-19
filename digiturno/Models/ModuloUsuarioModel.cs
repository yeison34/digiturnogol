using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class ModuloUsuarioModel
    {
        public int Id { get; set; }

        public string Idusuario { get; set; }

        public int? Idmodulo { get; set; }

        public bool Esactivo { get; set; }

        public ModuloUsuarioModel() { }

        public ModuloUsuarioModel(int p_id, string p_idusuario, int? p_idmodulo, bool p_esactivo)
        {
            Id = p_id;
            Idusuario = p_idusuario;
            Idmodulo = p_idmodulo;
            Esactivo = p_esactivo;
        }
    }
}