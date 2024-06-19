using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.Roles
{
    public class Roles
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Esactivo { get; set; }

        public Roles() { }

        public Roles(int p_id,string p_nombre,bool p_esactivo) { 
            Id = p_id;
            Nombre = p_nombre;
            Esactivo= p_esactivo;
        }
    }
}