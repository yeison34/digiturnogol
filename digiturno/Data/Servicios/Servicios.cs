using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.Servicios
{
    public class Servicios
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Esconsultas { get; set; }

        public bool Esasesoria { get; set; }

        public bool Esotros { get; set; }

        public string Icono { get; set; }

        public string Codigo { get; set; }

        public bool Escaja { get; set; }

        public Servicios(int p_id,string p_nombre,bool p_esconsultas,bool p_esasesoria,bool p_esotros,string p_icono,string p_codigo, bool p_escaja) { 
            Id= p_id;
            Nombre= p_nombre;
            Esconsultas= p_esconsultas;
            Esasesoria= p_esasesoria;
            Esotros= p_esotros;
            Icono= p_icono;
            Codigo= p_codigo;
            Escaja= p_escaja;
        }

        public Servicios() { }  
    }
}