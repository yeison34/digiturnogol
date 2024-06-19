using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace digiturno.Models
{
    public class AtencionClienteModel
    {
        public string Moduloatencion { get; set; }

        public bool Enatencion { get; set; }

        public string Turno { get; set; }

        public string Servicio { get; set; }

        public string Cedula { get; set; }

        public int Idturno { get; set; }

        public bool InicioAtencion { get; set; }

        public string Usuario { get; set; }
        public AtencionClienteModel() { }

        public AtencionClienteModel(string p_moduloatencion,bool p_enatencion,string p_turno,string p_servicio,string p_cedula,int p_idturno,bool p_inicioatencion,string p_usuario) { 
            Moduloatencion= p_moduloatencion;
            Enatencion= p_enatencion;
            Turno= p_turno;
            Servicio= p_servicio;
            Cedula= p_cedula;
            Idturno= p_idturno;
            InicioAtencion= p_inicioatencion;
            Usuario = p_usuario;
        }
    }
}