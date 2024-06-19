using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class TurnoImpresoModel
    {
        public int Idturno { get; set; }

        public string Descripcionturno { get; set; }

        public string Sucursal { get; set; }

        public string Cedula { get; set; }

        public string Empresa { get; set; }

        public DateTime Fecha { get; set; }

        public TurnoImpresoModel() { }

        public TurnoImpresoModel(int p_idturno,string p_descripcionturno, string p_sucursal,string p_cedula,string p_empresa,DateTime fecha) { 
            Idturno= p_idturno;
            Descripcionturno= p_descripcionturno;
            Sucursal= p_sucursal;
            Cedula= p_cedula;
            Empresa= p_empresa;
            Fecha= fecha;
        }
    }
}