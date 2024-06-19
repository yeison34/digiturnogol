using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using digiturno.Data.Servicios;
using digiturno.Data.Sucursal;
namespace digiturno.Data.Turno
{
    public class Turno
    {

        public int Id { get; set; }

        public int? Idsucursal { get; set; }

        public int? Idservicio { get; set; }  
        
        public int? Idmodulo { get; set; }

        public int Consecutivo { get; set; }

        public string Cedular { get; set; }

        public bool Esllamado { get; set; }

        public bool Nosepresento { get; set; }

        public bool Atendido { get; set; }
        public Sucursal.Sucursal sucursal {
            get
            {
                return SucursalData.ObtenerPorId(Idsucursal??0);
            }
        }
        
        public Servicios.Servicios servicio
        {
            get {
                return ServiciosData.ObtenerPorId(Idservicio??0);
            }
        }

        public Turno(int p_id,int? p_idsucursal,int? p_idservicio,int? p_idmodulo,int p_consecutivo,string p_cedular,bool p_esllamado,bool p_nosepresento,bool p_atendido) {
            Id=p_id;
            Idsucursal=p_idsucursal;
            Idservicio=p_idservicio;
            Idmodulo=p_idmodulo;
            Consecutivo=p_consecutivo;
            Cedular=p_cedular;
            Esllamado=p_esllamado;
            Nosepresento=p_nosepresento;
            Atendido=p_atendido;
        }

        public Turno() { }  
    }
}