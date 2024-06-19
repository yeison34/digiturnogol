using digiturno.Data.Roles;
using digiturno.Data.Servicios;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;

namespace digiturno.Data.ServicioRol
{
    public class ServicioRol
    {
        public int Id { get; set; }

        public int? Idservicio { get; set; }

        public int? Idrol { get; set; }

        public Servicios.Servicios servicio { get {
                return ServiciosData.ObtenerPorId(Idservicio??0);    
        } }

        public Roles.Roles rol{
            get
            {
                return RolesData.ObtenerPorId(Idservicio ?? 0);
            }
        }

        public ServicioRol() { }

        public ServicioRol(int p_id,int? p_idservicio,int? p_idrol) {
            Id = p_id;
            Idservicio= p_idservicio;
            Idrol = p_idrol;
        }
    }
}