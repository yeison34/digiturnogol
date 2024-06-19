using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class TurnoGenerarModel
    {
        public int Idturno { get; set; }

        public string Cedula { get; set; }

        public int Idservicio { get; set; }

        public List<ServiciosModel> Servicios { get; set; }
        public TurnoGenerarModel() { 
            Servicios= new List<ServiciosModel>();
        }

        public TurnoGenerarModel(int p_idturno,string p_cedula,int p_idservicio) {
            Idturno= p_idturno;
            Cedula= p_cedula;
            Idservicio= p_idservicio;
        }
    }
}