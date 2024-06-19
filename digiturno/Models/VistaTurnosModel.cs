using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class VistaTurnosModel
    {
        public int Idturno { get; set; }

        public int? Idsucursal { get; set; }

        public int? Idservicio { get; set; }

        public string Turno { get; set; }

        public string Cedular { get; set; }

        public string Servicio { get; set; }

        public string Sucursal { get; set; }

        public bool Esllamado { get; set; }

        public bool Nosepresento { get; set; }

        public bool Atendido { get; set; }

        public int? Idmodulo { get; set; }

        public string Modulo { get; set; }

        public VistaTurnosModel(int p_idturno, int? p_idsucursal, int? p_idservicio, string p_turno, string p_cedular, string p_servicio, string p_sucursal, bool p_esllamado, bool p_nosepresento, bool p_atendido,int? p_idmodulo,string p_modulo)
        {
            Idturno = p_idturno;
            Idsucursal = p_idsucursal;
            Idservicio = p_idservicio;
            Turno = p_turno;
            Cedular = p_cedular;
            Servicio = p_servicio;
            Sucursal = p_sucursal;
            Esllamado = p_esllamado;
            Nosepresento = p_nosepresento;
            Atendido = p_atendido;
            Idmodulo = p_idmodulo;
            Modulo=p_modulo;
        }
        public VistaTurnosModel() { }
    }
}