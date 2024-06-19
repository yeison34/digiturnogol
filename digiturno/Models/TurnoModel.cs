using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class TurnoModel
    {

        public int Id { get; set; }

        public int? Idsucursal { get; set; }

        public int? Idservicio { get; set; }

        public int? Idmodulo { get; set; }

        public int Consecutivo { get; set; }

        public string Cedular { get; set; }

        public bool Nosepresento { get; set; }

        public bool Atendido { get; set; }

        public TurnoModel(int p_id, int? p_idsucursal, int? p_idservicio, int? p_idmodulo, int p_consecutivo, string p_cedular, bool p_nosepresento, bool p_atendido)
        {
            Id = p_id;
            Idsucursal = p_idsucursal;
            Idservicio = p_idservicio;
            Idmodulo = p_idmodulo;
            Consecutivo = p_consecutivo;
            Cedular = p_cedular;
            Nosepresento = p_nosepresento;
            Atendido = p_atendido;
        }
        public TurnoModel() { }


    }
}